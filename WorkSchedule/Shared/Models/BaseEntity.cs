using Microsoft.EntityFrameworkCore.Update.Internal;
using Shared.Common;

namespace Shared.Models;
public abstract class BaseEntity
{
    public string Id { get; set; }
    public string LastUpdate { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
        LastUpdate = DateTime.Now.ToSchedule();
    }

    protected void ChangeLastUpdate()
    {
        LastUpdate = DateTime.Now.ToSchedule();
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
