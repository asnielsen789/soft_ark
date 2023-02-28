Opgave5.ScanDir("C:\\Users\\Kristian");

class Opgave5 {
    public static void ScanDir(string path) {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();

        // Udskriver alle filerne
        foreach (FileInfo file in files) {
            Console.WriteLine(file.Name);
        }
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Kalder rekursivt på alle undermapper
        foreach (DirectoryInfo subdir in dirs) {
            ScanDir(subdir.FullName);
        }        
    }
}