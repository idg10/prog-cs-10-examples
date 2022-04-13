using Microsoft.Office.Interop.PowerPoint;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var pptApp = new Application();
        Presentation pres = pptApp.Presentations.Open(args[0]);
        try
        {
            ProcessSlides(pres);
        }
        finally
        {
            pres.Close();
        }
    }

    static readonly string VideoOutputFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "RawSlideVideo");

    private static void ProcessSlides(Presentation pres)
    {
        Application app = pres.Application;
        string inputPptx = pres.FullName;
        Presentation scratchPres = app.Presentations.Add();
        scratchPres.ApplyTemplate(inputPptx);
        Directory.CreateDirectory(VideoOutputFolder);

        char[] badChars = Path.GetInvalidFileNameChars();
        try
        {
            for (int i = 1; i <= pres.Slides.Count; ++i)
            {
                var orig = pres.Slides[i];
                orig.Copy();
                SlideRange pasted = scratchPres.Slides.Paste();
                pasted.Design = orig.Design;
                pasted.SlideShowTransition.EntryEffect = PpEntryEffect.ppEffectNone;

                string slideBaseName = string.Format("{1} {0}",
                    orig.Shapes.HasTitle == Microsoft.Office.Core.MsoTriState.msoTrue ? orig.Shapes.Title.TextEffect.Text : "Slide",
                    i);
                foreach (char bad in badChars)
                {
                    slideBaseName = slideBaseName.Replace(bad.ToString(), "");
                }

                string videoFileName = slideBaseName + ".wmv";
                string videoPath = Path.Combine(VideoOutputFolder, videoFileName);
                scratchPres.CreateVideo(videoPath, UseTimingsAndNarrations: false, DefaultSlideDuration: 0, VertResolution: 768, FramesPerSecond: 30, Quality: 100);

                do
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(scratchPres.CreateVideoStatus);
                }
                while (scratchPres.CreateVideoStatus == PpMediaTaskStatus.ppMediaTaskStatusInProgress);

                pasted.Delete();
            }
        }
        finally
        {
            scratchPres.Close();
        }
    }
}