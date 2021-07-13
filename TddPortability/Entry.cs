using System;

namespace TddPortability
{
    public record Entry(int Id, int GegevensDientId, Uri RequestUri, DateTimeOffset Tijdstempel);
}