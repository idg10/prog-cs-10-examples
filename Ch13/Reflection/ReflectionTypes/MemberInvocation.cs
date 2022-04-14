using System.Reflection;

namespace ReflectionTypes
{
    public static class MemberInvocation
    {
        public static class ViaType
        {
            public static object? CreateAndInvokeMethod(
              string typeName, string member, params object[] args)
            {
                Type t = Type.GetType(typeName)
                    ?? throw new ArgumentException(
                        $"Type {typeName} not found", nameof(typeName));
                object instance = Activator.CreateInstance(t)!;
                return t.InvokeMember(
                  member,
                  BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
                  null,
                  instance,
                  args);
            }
        }

        public static class ViaMethodInfo
        {
            public static object? CreateAndInvokeMethod(
                string typeName, string member, params object[] args)
            {
                Type t = Type.GetType(typeName)
                    ?? throw new ArgumentException(
                        $"Type {typeName} not found", nameof(typeName));
                object instance = Activator.CreateInstance(t)!;
                MethodInfo m = t.GetMethod(member)
                    ?? throw new ArgumentException(
                        $"Method {member} not found", nameof(member)); ;
                return m.Invoke(instance, args);
            }
        }
    }
}