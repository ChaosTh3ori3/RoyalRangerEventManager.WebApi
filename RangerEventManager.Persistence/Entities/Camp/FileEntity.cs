namespace RangerEventManager.Persistence.Entities.Camp;

public class FileEntity
{
    public long FileId { get; set; }
    internal long? ParentFileId { get; set; }
    public FileEntity? ParentFile { get; set; }
    public string? Link { get; set; }
    public string? FolderName { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp { get; set; }
}