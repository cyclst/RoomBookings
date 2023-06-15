using System.Reflection;

namespace RoomBookings.Common.Application.Helpers;

public static class AssemblyHelpers
{
    public static IEnumerable<Assembly> GetReferencedAssemblies(this Assembly assembly, string assemblyPrefix)
    {
        var path = AppContext.BaseDirectory;  // returns bin/debug path
        var directory = new DirectoryInfo(path);

        IEnumerable<string> assemblyFileNames = new string[0];

        if (directory.Exists)
        {
            assemblyFileNames = directory.GetFiles($"{assemblyPrefix}*.dll").Select(f => f.Name);  // get only assembly files from debug path
        }

        yield return assembly;

        foreach (var assemblyFileName in assemblyFileNames)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(assemblyFileName);
            if (assembly.FullName == null || !assembly.FullName.Contains($"{assemblyName},"))
                yield return Assembly.LoadFrom(Path.Combine(path, assemblyFileName));
        }
    }
}
