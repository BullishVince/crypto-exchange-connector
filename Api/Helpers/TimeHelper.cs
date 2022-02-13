namespace Api.Helpers;

public static partial class TimeHelper {
    public static long ConvertDateTimeToUnixTimestamp(this DateTime dt) {
        return (long)dt.Subtract(DateTime.UnixEpoch).TotalSeconds;
    }

    public static DateTime ConvertUnixTimestampToDateTime(long unixTimestamp) {
        return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;
    }
}