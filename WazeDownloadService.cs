﻿using System.Data.Entity;

// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using WazeDownloader;
//
//    var WazeDownload = WazeDownload.FromJson(jsonString);

namespace WazeDownloader
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using J = Newtonsoft.Json.JsonPropertyAttribute;
    using R = Newtonsoft.Json.Required;
    using N = Newtonsoft.Json.NullValueHandling;


    public class WazeDownloadContext : DbContext
    {
        public DbSet<WazeDownload> WazeDownloads { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Jam> Jams { get; set; }

    }

    public partial class WazeDownload
    {
        public int WazeDownloadId { get; set; }
        [J("alerts")] public virtual List<Alert> Alerts { get; set; }
        [J("endTimeMillis")] public long EndTimeMillis { get; set; }
        [J("startTimeMillis")] public long StartTimeMillis { get; set; }
        [J("startTime")] public string StartTime { get; set; }
        [J("endTime")] public string EndTime { get; set; }
        [J("jams")] public virtual List<Jam> Jams { get; set; }
    }

    public partial class Alert
    {
        public int AlertId { get; set; }
        [J("country")] public string Country { get; set; }
        [J("nThumbsUp")] public long NThumbsUp { get; set; }
        [J("city", NullValueHandling = N.Ignore)] public string City { get; set; }
        [J("reportRating")] public long ReportRating { get; set; }
        [J("confidence")] public long Confidence { get; set; }
        [J("reliability")] public long Reliability { get; set; }
        [J("type")] public string Type { get; set; }
        [J("uuid")] public Guid Uuid { get; set; }
        [J("roadType")] public long RoadType { get; set; }
        [J("magvar")] public long Magvar { get; set; }
        [J("subtype")] public string Subtype { get; set; }
        [J("street")] public string Street { get; set; }
        [J("location")] public Location Location { get; set; }
        [J("pubMillis")] public long PubMillis { get; set; }
        public virtual WazeDownload WazeDownload { get; set; }
    }

    public partial class Location
    {
        public int LocationId { get; set; }
        [J("x")] public double X { get; set; }
        [J("y")] public double Y { get; set; }

    }

    public partial class Jam
    {
        public int JamId { get; set; }
        [J("country")] public string Country { get; set; }
        [J("city", NullValueHandling = N.Ignore)] public string City { get; set; }
        [J("level")] public long Level { get; set; }
        [J("line")] public Location[] Line { get; set; }
        [J("speedKMH")] public double SpeedKmh { get; set; }
        [J("length")] public long Length { get; set; }
        [J("turnType")] public string TurnType { get; set; }
        [J("type")] public string Type { get; set; }
        [J("uuid")] public long Uuid { get; set; }
        [J("endNode")] public string EndNode { get; set; }
        [J("speed")] public double Speed { get; set; }
        [J("segments")] public virtual List<Segment> Segments { get; set; }
        [J("roadType")] public long RoadType { get; set; }
        [J("delay")] public long Delay { get; set; }
        [J("street")] public string Street { get; set; }
        [J("id")] public long Id { get; set; }
        [J("pubMillis")] public long PubMillis { get; set; }
        [J("startNode", NullValueHandling = N.Ignore)] public string StartNode { get; set; }
        public virtual WazeDownload WazeDownload { get; set; }
    }

    public partial class Segment
    {
        public int SegmentId { get; set; }
    }

    public partial class WazeDownload
    {
        public static WazeDownload FromJson(string json) => JsonConvert.DeserializeObject<WazeDownload>(json, WazeDownloader.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WazeDownload self) => JsonConvert.SerializeObject(self, WazeDownloader.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
