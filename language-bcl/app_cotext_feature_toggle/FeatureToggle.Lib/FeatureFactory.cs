using System;

namespace FeatureToggle.Lib
{
    public static class FeatureFactory
    {
        public static IFeature Create()
        {
            /*
             * In this practice, we will evaluate how to provide feature toggling in .NET.
             * Please read the test and complete the code.
             *
             * Difficulty: Super Easy.
             */
            if (TryCreate<ExperimentalFeature>("experimental", out var feature))
            {
                return feature;
            }
            if (TryCreate<EdgeFeature>("edge", out feature))
            {
                return feature;
            }
            if (TryCreate<LegacyFeature>("legacy", out feature))
            {
                return feature;
            }
            return new NormalFeature();
        }

        private static bool TryCreate<T>(string switchName, out IFeature createdFeature) where T : IFeature, new()
        {
            createdFeature = default;
            
            AppContext.TryGetSwitch(switchName, out var enabled);
            if (!enabled) return false;

            createdFeature = new T();
            return true;
        }
    }
}