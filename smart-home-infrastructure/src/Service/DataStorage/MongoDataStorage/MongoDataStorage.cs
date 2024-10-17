using Domain.Enums;
using Infrastructure.MongoDb;
using MongoDB.Driver;
using Service.Common.Mappers;
using Service.Contracts.DataStorage;
using Service.Contracts.DataStorage.Dto;
using Service.DataStorage.MongoDataStorage.Documents;

namespace Service.DataStorage.MongoDataStorage;

public class MongoDataStorage : IDataStorage
{
    private readonly IMongoCollection<DeviceDocument> _deviceCollection;

    public MongoDataStorage(MongoDbInfrastructure mongoDbInfrastructure)
    {
        _deviceCollection = mongoDbInfrastructure.Database.GetCollection<DeviceDocument>("devices");
    }

    public Task<DeviceDataStorageDto> GetDeviceAsync(Guid deviceId, CancellationToken cancellationToken = default)
    {
        var filter = Builders<DeviceDocument>.Filter.Eq(x => x.Id, deviceId.ToString());
        var deviceDocument = _deviceCollection.Find(filter).FirstOrDefault(cancellationToken);

        return Task.FromResult(DataStorageDeviceToDocumentDeviceMapper.ApplyReverse(deviceDocument));
    }

    public async Task ChangeDeviceStatusAsync(Guid deviceId, DeviceStatus status, CancellationToken cancellationToken = default)
    {
        var filter = Builders<DeviceDocument>.Filter.Eq(x => x.Id, deviceId.ToString());
        var update = Builders<DeviceDocument>.Update.Set(x => x.Status, status);

        await _deviceCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }
}