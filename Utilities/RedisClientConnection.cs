namespace Netcorext.Extensions.Redis.Utilities;

public class RedisClientConnection<TRedis>
{
    private static Lazy<TRedis>? _lazyRedisClient;
    private static readonly object Locker = new();

    public RedisClientConnection(Func<TRedis> factory)
    {
        lock (Locker)
        {
            _lazyRedisClient ??= new Lazy<TRedis>(factory);
        }
    }

    public TRedis Client => _lazyRedisClient!.Value;
}