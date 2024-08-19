using System;
using YamlDotNet.Serialization;

namespace configuration.configs.configuration
{
    [Serializable]
    public class UnityCcdConfig
    {
        [YamlMember(Alias = "environment_name")]
        public string EnvironmentName;
        [YamlMember(Alias = "bucket_id_android")]
        public string BucketIDAndroid;
        [YamlMember(Alias = "bucket_id_ios")]
        public string BucketIDios;
        [YamlMember(Alias = "badge_name")]
        public string BadgeName;
    }
}