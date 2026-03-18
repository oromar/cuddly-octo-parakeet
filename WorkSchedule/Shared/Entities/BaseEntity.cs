using Shared.Common;

namespace Shared.Entities;
public abstract class BaseEntity
{
    public string Id { get; set; }
    public string LastUpdate { get; set; }
    public bool Deleted { get; set; }

    protected BaseEntity()
    {
        Deleted = false;
        Id = Guid.NewGuid().ToString();
        LastUpdate = DateTime.Now.ToSchedule();
    }

    protected void Update()
    {
        LastUpdate = DateTime.Now.ToSchedule();
    }

    public void Delete()
    {
        Update();
        Deleted = true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is BaseEntity entity)
        {
            return Id == entity.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 37;
    }
}
