namespace ToDoList.Data.Interface
{
    public interface IAuditedEntity
    {
        bool IsDeleted { get; set; }
        DateTime CreationTime { get; set; }
        DateTime? DeletetionTime { get; set; }
        DateTime? LastModificationTime { get; set; }
    }
}
