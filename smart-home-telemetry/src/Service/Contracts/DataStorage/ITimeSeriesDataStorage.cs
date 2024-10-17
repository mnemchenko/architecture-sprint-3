using Service.Contracts.DataStorage.Dto;

namespace Service.Contracts.DataStorage;

public interface ITimeSeriesDataStorage
{
    public Task AddTimeSeriesDataAsync(
        TimeSeriesPointDataDto timeSeriesPointData,
        CancellationToken cancellationToken = default);
}