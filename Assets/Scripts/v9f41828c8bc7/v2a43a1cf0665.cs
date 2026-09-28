using System.Collections.Generic;

namespace Generated
{
    
    internal struct vd4faabe99ed9
    {
        internal int Ring;
        internal float StartAngleDeg;
        internal float SpinDegPerSecond;
    }

    
    internal struct vf5d1c7c7a537
    {
        internal int Ring;
        internal float AngleDeg;
    }

    
    
    
    
    
    
    internal sealed class v2a43a1cf0665
    {
        internal int v151ede706684;
        internal bool vaae0b8061ef0;
        internal float BallStartAngleDeg;

        
        internal float[] GateStartAngleDeg = new float[v2fcef25e0767.vf7a7d1a4a386];

        internal readonly List<vd4faabe99ed9> Voids = new List<vd4faabe99ed9>();
        internal readonly List<vf5d1c7c7a537> Stars = new List<vf5d1c7c7a537>();

        
        internal int VerifiedStars;
        internal int VerifiedLivesLost;
        internal float VerifiedSecondsLeft;

        internal int va2223d4ebfdc
        {
            get { return this.Stars.Count; }
        }
    }
}
