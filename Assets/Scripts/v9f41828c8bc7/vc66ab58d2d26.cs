using UnityEngine;

namespace Generated
{
    
    
    
    
    internal readonly struct vc66ab58d2d26
    {
        internal readonly float v7e33c47b4165;
        internal readonly float ved450636f46e;
        internal readonly Vector2 Centre;
        internal readonly float v3a835b055823;
        internal readonly float vec61c212a544;

        internal vc66ab58d2d26(Camera camera)
        {
            float v08032ff17124 = camera.orthographicSize;
            float v3fd675930f7b = v08032ff17124 * camera.aspect;

            this.v7e33c47b4165 = v08032ff17124;
            this.ved450636f46e = v3fd675930f7b;
            this.Centre = new Vector2(0f, -0.07f * v08032ff17124);
            this.v3a835b055823 = v3fd675930f7b * 0.86f;
            this.vec61c212a544 = v3fd675930f7b * 0.26f;
        }

        internal float BallDiameter
        {
            get { return this.ved450636f46e * 0.105f; }
        }

        internal float StarDiameter
        {
            get { return this.ved450636f46e * 0.078f; }
        }

        internal float PortalDiameter
        {
            get { return this.ved450636f46e * 0.34f; }
        }

        internal float SparkSpread
        {
            get { return this.ved450636f46e * 0.14f; }
        }

        internal float ShakeAmplitude
        {
            get { return this.ved450636f46e * 0.02f; }
        }

        
        internal float RingRadius(int v87c1c391a755)
        {
            int last = v2fcef25e0767.vf7a7d1a4a386 - 1;
            if (last <= 0)
            {
                return this.v3a835b055823;
            }

            float t = Mathf.Clamp01(v87c1c391a755 / (float)last);
            return Mathf.Lerp(this.v3a835b055823, this.vec61c212a544, t);
        }

        internal Vector3 PointOnRing(int v87c1c391a755, float v75bb14d6312e)
        {
            float radius = this.RingRadius(v87c1c391a755);
            float radians = v75bb14d6312e * Mathf.Deg2Rad;
            return new Vector3(
                this.Centre.x + (Mathf.Cos(radians) * radius),
                this.Centre.y + (Mathf.Sin(radians) * radius),
                0f);
        }

        
        
        
        
        
        
        internal static Vector2 SizeFor(SpriteRenderer renderer, float targetDiameter)
        {
            if (renderer == null || renderer.sprite == null)
            {
                return new Vector2(targetDiameter, targetDiameter);
            }

            Vector2 native = renderer.sprite.bounds.size;
            float longest = Mathf.Max(native.x, native.y);
            if (longest <= Mathf.Epsilon)
            {
                return new Vector2(targetDiameter, targetDiameter);
            }

            float k = targetDiameter / longest;
            return new Vector2(native.x * k, native.y * k);
        }
    }
}
