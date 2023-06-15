using RoomBookings.Common.Domain;

namespace RoomBookings.Common.Test;

public class InMemoryRepository<T> where T : Entity, IAggregateRoot
{
    private Dictionary<int, T> _items = new Dictionary<int, T>();

    public async Task<T> GetByIdAsync(int id)
    {
        var item = _items.ContainsKey(id) ? _items[id] : default;

        return await Task.FromResult(item);
    }


    public IQueryable<T> Query()
    {
        return _items.Values.AsQueryable();
    }

    public async Task<int> AddAsync(T item)
    {
        if (item.Id != 0)
            throw new ArgumentException("Item already added to repository");

        var maxId = _items.Keys.Count > 1 ? _items.Keys.Max() : 0;

        item.Id = maxId + 1;

        _items.Add(item.Id, item);

        return await Task.FromResult(item.Id);
    }

    public async Task DeleteAsync(int i)
    {
        await Task.Run(() =>
        {

        });
    }

    public void Update(T item)
    {

    }
}
