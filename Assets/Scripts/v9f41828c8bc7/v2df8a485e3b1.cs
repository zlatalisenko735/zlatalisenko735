using UnityEngine;

namespace Generated
{
    
    
    
    
    
    
    
    
    
    
    
    internal static class v2df8a485e3b1
    {
        private const float va013358541f7 = 8f;
        private const int vc8f69959a114 = 1;

        
        internal static int vf11a33e01efb(int vc4fb88665bf9, int vc0f539399e0f)
        {
            return (vc4fb88665bf9 * 7919) ^ (vc0f539399e0f * 104729);
        }

        internal static v2a43a1cf0665 v771befea9f21(int vc4fb88665bf9, int vc0f539399e0f)
        {
            for (int tries = 0; tries < v2fcef25e0767.vee3bd02207b5; tries++)
            {
                int va2513f29b45c = vf11a33e01efb(vc4fb88665bf9, vc0f539399e0f + tries);

                
                
                
                System.Random v45591a985a4f = new System.Random(va2513f29b45c);
                v2a43a1cf0665 vc60dc29daf9a = v5011fae1170c(va2513f29b45c, v45591a985a4f);

                if (v740232d1d152(vc60dc29daf9a))
                {
                    Debug.Log(string.Format(
                        vfe5e7a4690fb.vfc1252d39c44(0),
                        vc60dc29daf9a.v151ede706684,
                        vc4fb88665bf9,
                        vc0f539399e0f + tries,
                        vc60dc29daf9a.VerifiedStars,
                        vc60dc29daf9a.va2223d4ebfdc,
                        vc60dc29daf9a.Voids.Count,
                        vc60dc29daf9a.VerifiedLivesLost,
                        vc60dc29daf9a.VerifiedSecondsLeft));
                    return vc60dc29daf9a;
                }
            }

            Debug.Log(string.Format(
                vfe5e7a4690fb.vfc1252d39c44(1),
                vc4fb88665bf9,
                vc0f539399e0f));
            return v34e321abe020();
        }

        private static v2a43a1cf0665 v5011fae1170c(int va2513f29b45c, System.Random v45591a985a4f)
        {
            v2a43a1cf0665 vc60dc29daf9a = new v2a43a1cf0665();
            vc60dc29daf9a.v151ede706684 = va2513f29b45c;
            vc60dc29daf9a.BallStartAngleDeg = (float)(v45591a985a4f.NextDouble() * 360.0);

            float v68087183cec7 = 0f;
            float angle = vc60dc29daf9a.BallStartAngleDeg;

            for (int vd4a5bb6e81a6 = 0; vd4a5bb6e81a6 < v2fcef25e0767.vf7a7d1a4a386; vd4a5bb6e81a6++)
            {
                float vb90185283bdf = v7b2cf7ac4b07.v9b8e2f194b5d(vd4a5bb6e81a6);

                v7ffbd6b24e94(vc60dc29daf9a, v45591a985a4f, vd4a5bb6e81a6, angle, v68087183cec7, vb90185283bdf);

                float hopFraction = Lerp(v45591a985a4f, v2fcef25e0767.v4c72e34215ee, v2fcef25e0767.v6d86e1317382);
                float v4ea33cf4308f = v68087183cec7 + (vb90185283bdf * hopFraction);
                float hopAngle = v7b2cf7ac4b07.vc0f8000d3d96(angle, vd4a5bb6e81a6, v68087183cec7, v4ea33cf4308f);

                
                
                vc60dc29daf9a.GateStartAngleDeg[vd4a5bb6e81a6] =
                    v7b2cf7ac4b07.v67fcbe7df1ad(hopAngle, v2fcef25e0767.v33b19fbdc041, v4ea33cf4308f);

                vf57508fe9d7b(vc60dc29daf9a, v45591a985a4f, vd4a5bb6e81a6, angle, v68087183cec7, v4ea33cf4308f, vb90185283bdf);

                
                
                int nextRing = Mathf.Min(vd4a5bb6e81a6 + 1, v2fcef25e0767.vf7a7d1a4a386 - 1);
                float hopSeconds = v7b2cf7ac4b07.ve339e4c9197b(v4ea33cf4308f);
                float landedPhase = v7b2cf7ac4b07.vb7fe69f7561b(hopSeconds + v2fcef25e0767.vdca2452f0b77);

                angle = v7b2cf7ac4b07.vc0f8000d3d96(hopAngle, nextRing, v4ea33cf4308f, landedPhase);
                v68087183cec7 = landedPhase;
            }

            return vc60dc29daf9a;
        }

        private static void v7ffbd6b24e94(
            v2a43a1cf0665 vc60dc29daf9a,
            System.Random v45591a985a4f,
            int vd4a5bb6e81a6,
            float vf873d797bf04,
            float v2b619c0b0493,
            float vb90185283bdf)
        {
            int count = v2fcef25e0767.v059ed516351c[vd4a5bb6e81a6];
            if (count <= 0)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                float slot = count == 1 ? 0.5f : i / (float)(count - 1);
                float fraction = Mathf.Lerp(
                                     v2fcef25e0767.v9b20160088da,
                                     v2fcef25e0767.vb2f85712979c,
                                     slot) +
                                 Lerp(v45591a985a4f, -v2fcef25e0767.v571f6dfd6a11, v2fcef25e0767.v571f6dfd6a11);

                vf5d1c7c7a537 star;
                star.Ring = vd4a5bb6e81a6;
                star.AngleDeg = v7b2cf7ac4b07.vc0f8000d3d96(
                    vf873d797bf04, vd4a5bb6e81a6, v2b619c0b0493, v2b619c0b0493 + (vb90185283bdf * fraction));
                vc60dc29daf9a.Stars.Add(star);
            }
        }

        private static void vf57508fe9d7b(
            v2a43a1cf0665 vc60dc29daf9a,
            System.Random v45591a985a4f,
            int vd4a5bb6e81a6,
            float vf873d797bf04,
            float v2b619c0b0493,
            float v4ea33cf4308f,
            float vb90185283bdf)
        {
            int wanted = v2fcef25e0767.v9c1f4931be41[vd4a5bb6e81a6];
            if (wanted <= 0)
            {
                return;
            }

            float leadCatch = v4ea33cf4308f + (vb90185283bdf * v2fcef25e0767.v092426807903[vd4a5bb6e81a6]);
            vd4faabe99ed9 lead;
            if (!v9a11fe461079(
                    vd4a5bb6e81a6,
                    vf873d797bf04,
                    v2b619c0b0493,
                    leadCatch,
                    Lerp(v45591a985a4f, v2fcef25e0767.v372004fec1f5, v2fcef25e0767.v51fca74c84a3),
                    out lead))
            {
                return;
            }

            vc60dc29daf9a.Voids.Add(lead);

            if (wanted < 2)
            {
                return;
            }

            float trailCatch = leadCatch +
                               (vb90185283bdf * Lerp(v45591a985a4f, v2fcef25e0767.v1e0e5c68e496, v2fcef25e0767.v346e955deab4));
            vd4faabe99ed9 trail;
            if (!v9a11fe461079(
                    vd4a5bb6e81a6,
                    vf873d797bf04,
                    v2b619c0b0493,
                    trailCatch,
                    Lerp(v45591a985a4f, v2fcef25e0767.vbac41cbb8f2e, v2fcef25e0767.vf16356ada1e2),
                    out trail))
            {
                return;
            }

            
            float leadCentre = v7b2cf7ac4b07.v48d349bd7047(
                lead.StartAngleDeg, lead.SpinDegPerSecond, trailCatch);
            float trailCentre = v7b2cf7ac4b07.v48d349bd7047(
                trail.StartAngleDeg, trail.SpinDegPerSecond, trailCatch);
            if (v7b2cf7ac4b07.v313a374550cf(leadCentre, trailCentre) < v2fcef25e0767.va79b25d438e8)
            {
                return;
            }

            vc60dc29daf9a.Voids.Add(trail);
        }

        
        
        
        
        
        
        
        private static bool v9a11fe461079(
            int vd4a5bb6e81a6,
            float vf873d797bf04,
            float v2b619c0b0493,
            float v115a9a8932ee,
            float v20b38f6a2be9,
            out vd4faabe99ed9 v3338e7cccd35)
        {
            v3338e7cccd35 = default(vd4faabe99ed9);

            float spin = v7b2cf7ac4b07.v2d1b854d5fdf(vd4a5bb6e81a6, v20b38f6a2be9);
            if ((v115a9a8932ee - v2b619c0b0493) >= v7b2cf7ac4b07.vc3e67a01c7eb(vd4a5bb6e81a6, spin))
            {
                return false;
            }

            float ballAngle = v7b2cf7ac4b07.vc0f8000d3d96(vf873d797bf04, vd4a5bb6e81a6, v2b619c0b0493, v115a9a8932ee);
            float contactCentre = v7b2cf7ac4b07.v27238e18d27f(ballAngle + (v2fcef25e0767.v2637b2b53f6b * 0.5f));

            v3338e7cccd35.Ring = vd4a5bb6e81a6;
            v3338e7cccd35.SpinDegPerSecond = spin;
            v3338e7cccd35.StartAngleDeg = v7b2cf7ac4b07.v67fcbe7df1ad(contactCentre, spin, v115a9a8932ee);
            return true;
        }

        
        
        
        
        private static bool v740232d1d152(v2a43a1cf0665 vc60dc29daf9a)
        {
            int vd4a5bb6e81a6 = 0;
            float angle = vc60dc29daf9a.BallStartAngleDeg;
            float v68087183cec7 = 0f;
            float elapsed = 0f;
            float timeLeft = v2fcef25e0767.v6dff522e9a2e;
            int ve484923919d2 = v2fcef25e0767.va721dcc49ab3;
            int va94cdbd37add = 0;
            float hopUntil = -1f;
            float invulnerableUntil = -1f;
            bool wasInsideSector = false;

            bool[] taken = new bool[vc60dc29daf9a.Stars.Count];
            int[] remainingOnRing = new int[v2fcef25e0767.vf7a7d1a4a386];
            for (int i = 0; i < vc60dc29daf9a.Stars.Count; i++)
            {
                remainingOnRing[vc60dc29daf9a.Stars[i].Ring]++;
            }

            float step = v2fcef25e0767.v1c5582c3deab;
            while (timeLeft > 0f)
            {
                float advance = v7b2cf7ac4b07.v85ce5523d6d5(elapsed) * step;
                v68087183cec7 += advance;
                angle = v7b2cf7ac4b07.v27238e18d27f(angle + (v7b2cf7ac4b07.v443e09775cc6(vd4a5bb6e81a6) * advance));
                elapsed += step;
                timeLeft -= step;

                for (int i = 0; i < vc60dc29daf9a.Stars.Count; i++)
                {
                    if (taken[i] || vc60dc29daf9a.Stars[i].Ring != vd4a5bb6e81a6)
                    {
                        continue;
                    }

                    if (v7b2cf7ac4b07.v313a374550cf(angle, vc60dc29daf9a.Stars[i].AngleDeg) > v2fcef25e0767.vbf9203b11e1e)
                    {
                        continue;
                    }

                    taken[i] = true;
                    va94cdbd37add++;
                    remainingOnRing[vd4a5bb6e81a6]--;
                    timeLeft = Mathf.Min(timeLeft + v2fcef25e0767.vff26fbb3f4cd, v2fcef25e0767.v6dff522e9a2e);
                }

                bool hopping = elapsed < hopUntil;
                bool insideSector = va47d4f337348(vc60dc29daf9a, vd4a5bb6e81a6, angle, v68087183cec7);

                
                
                if (insideSector && !wasInsideSector && !hopping && elapsed >= invulnerableUntil)
                {
                    ve484923919d2--;
                    invulnerableUntil = elapsed + v2fcef25e0767.ve04ad6393de6;
                    vd4a5bb6e81a6 = Mathf.Max(0, vd4a5bb6e81a6 - 1);
                    insideSector = false;

                    if (ve484923919d2 <= 0)
                    {
                        vc60dc29daf9a.VerifiedStars = va94cdbd37add;
                        vc60dc29daf9a.VerifiedLivesLost = v2fcef25e0767.va721dcc49ab3;
                        vc60dc29daf9a.VerifiedSecondsLeft = timeLeft;
                        return false;
                    }
                }

                wasInsideSector = insideSector;

                if (hopping || remainingOnRing[vd4a5bb6e81a6] > 0)
                {
                    continue;
                }

                float gateCentre = v7b2cf7ac4b07.v48d349bd7047(
                    vc60dc29daf9a.GateStartAngleDeg[vd4a5bb6e81a6], v2fcef25e0767.v33b19fbdc041, v68087183cec7);
                if (!v7b2cf7ac4b07.v2dd74febdf8a(angle, gateCentre, v2fcef25e0767.vdb9f91ca9ce7))
                {
                    continue;
                }

                if (vd4a5bb6e81a6 < v2fcef25e0767.vf7a7d1a4a386 - 1)
                {
                    vd4a5bb6e81a6++;
                    hopUntil = elapsed + v2fcef25e0767.vdca2452f0b77;
                    continue;
                }

                if (va94cdbd37add < v2fcef25e0767.v19c1a0375d93)
                {
                    continue;
                }

                vc60dc29daf9a.VerifiedStars = va94cdbd37add;
                vc60dc29daf9a.VerifiedLivesLost = v2fcef25e0767.va721dcc49ab3 - ve484923919d2;
                vc60dc29daf9a.VerifiedSecondsLeft = timeLeft;

                return vc60dc29daf9a.VerifiedLivesLost <= vc8f69959a114 && timeLeft >= va013358541f7;
            }

            vc60dc29daf9a.VerifiedStars = va94cdbd37add;
            vc60dc29daf9a.VerifiedLivesLost = v2fcef25e0767.va721dcc49ab3 - ve484923919d2;
            vc60dc29daf9a.VerifiedSecondsLeft = 0f;
            return false;
        }

        
        internal static bool va47d4f337348(v2a43a1cf0665 vc60dc29daf9a, int vd4a5bb6e81a6, float v75bb14d6312e, float v68087183cec7)
        {
            for (int i = 0; i < vc60dc29daf9a.Voids.Count; i++)
            {
                vd4faabe99ed9 sector = vc60dc29daf9a.Voids[i];
                if (sector.Ring != vd4a5bb6e81a6)
                {
                    continue;
                }

                float centre = v7b2cf7ac4b07.v48d349bd7047(
                    sector.StartAngleDeg, sector.SpinDegPerSecond, v68087183cec7);
                if (v7b2cf7ac4b07.v2dd74febdf8a(v75bb14d6312e, centre, v2fcef25e0767.v2637b2b53f6b))
                {
                    return true;
                }
            }

            return false;
        }

        
        
        
        
        private static v2a43a1cf0665 v34e321abe020()
        {
            v2a43a1cf0665 vc60dc29daf9a = new v2a43a1cf0665();
            vc60dc29daf9a.vaae0b8061ef0 = true;
            vc60dc29daf9a.BallStartAngleDeg = 90f;

            float v68087183cec7 = 0f;
            float angle = vc60dc29daf9a.BallStartAngleDeg;

            for (int vd4a5bb6e81a6 = 0; vd4a5bb6e81a6 < v2fcef25e0767.vf7a7d1a4a386; vd4a5bb6e81a6++)
            {
                float vb90185283bdf = v7b2cf7ac4b07.v9b8e2f194b5d(vd4a5bb6e81a6);
                int v9e5cb0549284 = v2fcef25e0767.v059ed516351c[vd4a5bb6e81a6];

                for (int i = 0; i < v9e5cb0549284; i++)
                {
                    float slot = v9e5cb0549284 == 1 ? 0.5f : i / (float)(v9e5cb0549284 - 1);
                    float fraction = Mathf.Lerp(
                        v2fcef25e0767.v9b20160088da, v2fcef25e0767.vb2f85712979c, slot);

                    vf5d1c7c7a537 star;
                    star.Ring = vd4a5bb6e81a6;
                    star.AngleDeg = v7b2cf7ac4b07.vc0f8000d3d96(
                        angle, vd4a5bb6e81a6, v68087183cec7, v68087183cec7 + (vb90185283bdf * fraction));
                    vc60dc29daf9a.Stars.Add(star);
                }

                float v4ea33cf4308f = v68087183cec7 + (vb90185283bdf * 1.18f);
                float hopAngle = v7b2cf7ac4b07.vc0f8000d3d96(angle, vd4a5bb6e81a6, v68087183cec7, v4ea33cf4308f);
                vc60dc29daf9a.GateStartAngleDeg[vd4a5bb6e81a6] =
                    v7b2cf7ac4b07.v67fcbe7df1ad(hopAngle, v2fcef25e0767.v33b19fbdc041, v4ea33cf4308f);

                if (v2fcef25e0767.v9c1f4931be41[vd4a5bb6e81a6] > 0)
                {
                    vd4faabe99ed9 sector;
                    if (v9a11fe461079(
                            vd4a5bb6e81a6,
                            angle,
                            v68087183cec7,
                            v4ea33cf4308f + (vb90185283bdf * v2fcef25e0767.v092426807903[vd4a5bb6e81a6]),
                            (v2fcef25e0767.v372004fec1f5 + v2fcef25e0767.v51fca74c84a3) * 0.5f,
                            out sector))
                    {
                        vc60dc29daf9a.Voids.Add(sector);
                    }
                }

                int nextRing = Mathf.Min(vd4a5bb6e81a6 + 1, v2fcef25e0767.vf7a7d1a4a386 - 1);
                float landedPhase = v7b2cf7ac4b07.vb7fe69f7561b(
                    v7b2cf7ac4b07.ve339e4c9197b(v4ea33cf4308f) + v2fcef25e0767.vdca2452f0b77);

                angle = v7b2cf7ac4b07.vc0f8000d3d96(hopAngle, nextRing, v4ea33cf4308f, landedPhase);
                v68087183cec7 = landedPhase;
            }

            return vc60dc29daf9a;
        }

        private static float Lerp(System.Random v45591a985a4f, float vabb51165a107, float v2acee24e990d)
        {
            return vabb51165a107 + ((float)v45591a985a4f.NextDouble() * (v2acee24e990d - vabb51165a107));
        }
    }
}

internal static class vfe5e7a4690fb
{
    private const byte v388c56509c4e = 0x63;

    private const string v5477cd5e6ad4 = "A200000000dff085fe73aca7f7428bc32ddb2bbcbb5175c25ec6d0aef971f7682e4df1d533bc954e8fbc1af754e2e23e36e008a35152cfb92eb5f9c3670d1e77d2661e2e2e36b653603d1f4e17376e3fe3bbfb87a620d08a81549ebadf47c28e04893773f8";
    private const string v946bec26381d = "A20000000107dfc905425775042b04cf7a67954e9626ac772bce78f20117ff9a53836e715fe5f1471c0a7cdad917e50b14f8207f421fc340fe81bfae00b54b3b71343c94edb8890cb06a03afa292e8fea229d460d4ea06013ff9e5832ff43f928bbb7b";

    internal static string vfc1252d39c44(int id)
    {
        switch (id)
        {
            case 0: return vca1648a895b4(v5477cd5e6ad4);
            case 1: return vca1648a895b4(v946bec26381d);
            default: return string.Empty;
        }
    }

    private static string vca1648a895b4(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v388c56509c4e * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
        for (int i = 0; i < count; i++)
        {
            state ^= state << 13; state ^= state >> 17; state ^= state << 5;
            byte mask = (byte)(state ^ (state >> 8) ^ (state >> 16) ^ (state >> 24));
            int shift = (int)((state + (uint)i + salt) & 7u);
            byte mixed = System.Convert.ToByte(hex.Substring(18 + (count - 1 - i) * 2, 2), 16);
            byte rotated = shift == 0 ? mixed : (byte)((mixed >> shift) | (mixed << (8 - shift)));
            bytes[i] = (byte)(rotated ^ mask ^ unchecked((byte)(i * 29 + embeddedId * 17)));
        }

        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}
