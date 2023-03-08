namespace DirectoryExplorer.Models
{
    public class DirectoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentDirectoryId { get; set; }

        public virtual DirectoryModel? ParentDirectory { get; set; }
        public virtual ICollection<DirectoryModel>? ChildDirectories { get; set; }
    }
}
