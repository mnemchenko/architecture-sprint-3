using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.Options;
using Service.Contracts.DataStorage;
using Service.Contracts.DataStorage.Dto;
using Service.Contracts.DataStorage.Exceptions;
using Service.DataStorage.InfluxTimeSeriesDataStorage.Settings;

namespace Service.DataStorage.InfluxTimeSeriesDataStorage;

public class InfluxTimeSeriesDataStorage : ITimeSeriesDataStorage
{
    private readonly IInfluxDBClient _influxDbClient;

    private readonly string _bucket;

    private readonly string _organization;

    public InfluxTimeSeriesDataStorage(
        IOptions<InfluxDbSettings> settings)
    {
        _bucket = settings.Value.Bucket;

        _organization = settings.Value.Organization;

        _influxDbClient = new InfluxDBClient(
            settings.Value.Url,
            settings.Value.Token);
    }

    public Task AddTimeSeriesDataAsync(TimeSeriesPointDataDto timeSeriesPointData, CancellationToken cancellationToken = default)
    {
        try
        {
            var writeApi = _influxDbClient.GetWriteApi();

            var point = PointData.Measurement(timeSeriesPointData.Measurement)
                .Tag("deviceId", timeSeriesPointData.DeviceId.ToString())
                .Field(timeSeriesPointData.FieldName, timeSeriesPointData.Value)
                .Timestamp(timeSeriesPointData.Time, WritePrecision.Ns);

            writeApi.WritePoint(
                point,
                _bucket,
                _organization);

            return Task.CompletedTask;
        }
        catch (Exception exception)
        {
            throw new DataStorageServiceException("Data Storage: Failed to add time series data", exception);
        }
    }
}