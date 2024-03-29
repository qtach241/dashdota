﻿namespace GSClient.Nodes
{
    /// <summary>
    /// Information about the provider of this GameState
    /// </summary>
    public class Provider : Node
    {
        /// <summary>
        /// Game name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Game's Steam AppID
        /// </summary>
        public readonly int AppID;

        /// <summary>
        /// Game's version
        /// </summary>
        public readonly int Version;

        /// <summary>
        /// Current timestamp
        /// </summary>
        public readonly string TimeStamp;

        internal Provider(string json_data) : base(json_data)
        {
            Name = GetString("name");
            AppID = GetInt("appid");
            Version = GetInt("version");
            TimeStamp = GetString("timestamp");
        }
    }
}
