using System.Collections.Concurrent;

namespace SignalRServer.Handlers;

public class HubConnectionManager
{
    private static readonly ConcurrentDictionary<string, string> _connectionToUserIdMap = new();
    private static readonly ConcurrentDictionary<string, string> _userIdToConnectionMap = new();

    public static bool AddConnection(string userId, string connectionId)
    {
        if (_connectionToUserIdMap.TryGetValue(connectionId, out var existingUserId))
        {
            RemoveConnection(connectionId);
        }

        if (_userIdToConnectionMap.TryGetValue(userId, out var existingConnectionId))
        {
            RemoveUser(userId);
        }

        bool res = false;
        res = _connectionToUserIdMap.TryAdd(connectionId, userId);

        res &= _userIdToConnectionMap.TryAdd(userId, connectionId);

        return res;
    }

    public static void RemoveConnection(string connectionId)
    {
        if (_connectionToUserIdMap.TryGetValue(connectionId, out var userId))
        {
            _connectionToUserIdMap.TryRemove(connectionId, out _);
            _userIdToConnectionMap.TryRemove(userId, out _);
        }
    }

    public static void RemoveUser(string userId)
    {
        if (_userIdToConnectionMap.TryGetValue(userId, out var connectionId))
        {
            _connectionToUserIdMap.TryRemove(connectionId, out _);
            _userIdToConnectionMap.TryRemove(userId, out _);
        }
    }

    public static string? GetUserId(string connectionId)
    {
        _connectionToUserIdMap.TryGetValue(connectionId, out var userId);
        return userId;
    }

    public static string? GetConnectionId(string userId)
    {
        _userIdToConnectionMap.TryGetValue(userId, out var connectionId);
        return connectionId;
    }

}