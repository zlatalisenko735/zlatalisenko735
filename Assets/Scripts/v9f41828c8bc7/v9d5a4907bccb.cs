using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Generated
{
    
    
    
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class v9d5a4907bccb : MonoBehaviour
    {
        
        private const int vd85d596676c6 = 0;

        
        private const int v28306a333fb7 = 1;

        [Header("Scene")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _fieldRoot;
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private v0339ae2b922a _input;

        [Header("Prefabs")]
        [SerializeField] private v4de849b5d17b _ringPrefab;
        [SerializeField] private vfbb09e8be3f9 _gatePrefab;
        [SerializeField] private vfbb09e8be3f9 _voidPrefab;
        [SerializeField] private vf7f1a8d33f1f _starPrefab;
        [SerializeField] private vb62326ae72e0 _sparkPrefab;
        [SerializeField] private v73d0b57143d4 _ball;
        [SerializeField] private vccb3c5e19a42 _portal;

        [Header("UI")]
        [SerializeField] private vcccb7af22a7e _hud;
        [SerializeField] private v22bca37fe978 _popups;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _pauseButton;

        private readonly List<v4de849b5d17b> v66a35b48c53e = new List<v4de849b5d17b>();
        private readonly List<vfbb09e8be3f9> v206d4b7b6d81 = new List<vfbb09e8be3f9>();
        private readonly List<vfbb09e8be3f9> v6782cdaf9592 = new List<vfbb09e8be3f9>();
        private readonly List<vf7f1a8d33f1f> vc363d4a56ef4 = new List<vf7f1a8d33f1f>();

        private vc66ab58d2d26 va45bad433a69;
        private v2a43a1cf0665 va2c17c6bb56d;

        private RoundPhase v883cb38eaf25 = RoundPhase.Idle;
        private float v2805cf436128;
        private float va9b1452c59d9;
        private float ve5f18ed44c89;
        private float v7ada1d8af2d5;
        private float va7911a4daf47;
        private int v420488f25267;
        private int vd13c7b84ceab;
        private int v1888f9268bbb;
        private int v5dd6cbf6d171;
        private int v81f4ec851c85;

        private float vbab7e6960007;
        private float vdca4c35aedd7;
        private float va0c1d67c469d;
        private float v2a7f2dfd2da4;
        private bool vef3616525aa1;
        private float vf0d5e8567a4a;
        private Vector3 vbf51ff0d406e;
        private float ve30da349d4d8;

        private enum RoundPhase
        {
            Idle,
            Running,
            Diving,
            Finished,
        }

        
        
        private void Start()
        {
            this.va45bad433a69 = new vc66ab58d2d26(this._camera);
            this.vbf51ff0d406e = this._fieldRoot.localPosition;

            this.FitBackground();
            this.BuildField();
            this.BindUi();
            this.ResetRound();
        }

        private void FitBackground()
        {
            
            v8a29287814e6.v29234c61c1f5(this._background, v8a29287814e6.vccc1ebc9a17f);

            if (this._background.sprite == null)
            {
                return;
            }

            Vector2 native = this._background.sprite.bounds.size;
            if (native.x <= Mathf.Epsilon || native.y <= Mathf.Epsilon)
            {
                return;
            }

            
            
            
            float cover = Mathf.Max(
                (this.va45bad433a69.ved450636f46e * 2f) / native.x,
                (this.va45bad433a69.v7e33c47b4165 * 2f) / native.y);

            this._background.transform.position = Vector3.zero;
            this._background.size = new Vector2(native.x * cover, native.y * cover);
        }

        private void BuildField()
        {
            this.va2c17c6bb56d = v2df8a485e3b1.v771befea9f21(v5e10cba67c40.v8cf2e38cad98, v5e10cba67c40.v26af21a74541);

            for (int vd4a5bb6e81a6 = 0; vd4a5bb6e81a6 < v2fcef25e0767.vf7a7d1a4a386; vd4a5bb6e81a6++)
            {
                v4de849b5d17b track = Instantiate(this._ringPrefab, this._fieldRoot);
                track.v2f5e2173b1a9(this.va45bad433a69, vd4a5bb6e81a6, va7c9379be56b.vb477f7abc689(va7c9379be56b.vb09e0d1013c6, 0.4f));
                this.v66a35b48c53e.Add(track);

                vfbb09e8be3f9 gate = Instantiate(this._gatePrefab, this._fieldRoot);
                gate.v2f5e2173b1a9(this.va45bad433a69, vd4a5bb6e81a6, v8a29287814e6.vc79f5cae6e8b, va7c9379be56b.va10e8b276e1d);
                this.v206d4b7b6d81.Add(gate);
            }

            for (int i = 0; i < this.va2c17c6bb56d.Voids.Count; i++)
            {
                vfbb09e8be3f9 sector = Instantiate(this._voidPrefab, this._fieldRoot);
                sector.v2f5e2173b1a9(
                    this.va45bad433a69,
                    this.va2c17c6bb56d.Voids[i].Ring,
                    v8a29287814e6.vf14995e756a0,
                    va7c9379be56b.vb477f7abc689(va7c9379be56b.va9af105d7347, 0.92f));
                this.v6782cdaf9592.Add(sector);
            }

            for (int i = 0; i < this.va2c17c6bb56d.Stars.Count; i++)
            {
                vf7f1a8d33f1f star = Instantiate(this._starPrefab, this._fieldRoot);
                star.v2f5e2173b1a9(this.va45bad433a69, this.va2c17c6bb56d.Stars[i]);
                this.vc363d4a56ef4.Add(star);
            }

            this._ball.v2f5e2173b1a9(this.va45bad433a69);
            this._portal.v2f5e2173b1a9(this.va45bad433a69);
        }

        private void BindUi()
        {
            this._backButton.onClick.AddListener(() => this.LoadScene(vd85d596676c6));
            this._pauseButton.onClick.AddListener(() => this.Pause());

            this._popups.v1a0df36b121b(
                () => this.Resume(),
                () => this.Restart(false),
                () => this.Restart(true),
                () => this.LoadScene(vd85d596676c6));

            this._input.v4b6ed93e4cbf += this.OnTapped;
        }

        private void OnDestroy()
        {
            this._input.v4b6ed93e4cbf -= this.OnTapped;
        }

        private void ResetRound()
        {
            this.v883cb38eaf25 = RoundPhase.Idle;
            this.v2805cf436128 = v2fcef25e0767.v19b10f0edfe7;
            this.va9b1452c59d9 = 0f;
            this.ve5f18ed44c89 = 0f;
            this.v7ada1d8af2d5 = v2fcef25e0767.v6dff522e9a2e;
            this.va7911a4daf47 = this.va2c17c6bb56d.BallStartAngleDeg;
            this.v420488f25267 = 0;
            this.vd13c7b84ceab = v2fcef25e0767.va721dcc49ab3;
            this.v1888f9268bbb = 0;
            this.v5dd6cbf6d171 = 0;
            this.v81f4ec851c85 = 0;
            this.vef3616525aa1 = false;

            this._input.vb58ed50ae678(true);

            this._hud.v9f2343748199(0, v2fcef25e0767.v19c1a0375d93);
            this._hud.vde601af15752(this.vd13c7b84ceab);
            this._hud.v0462b1da3859(this.v7ada1d8af2d5, v2fcef25e0767.v6dff522e9a2e);
            this._hud.v78a95eb65a39(this.v420488f25267, v2fcef25e0767.vf7a7d1a4a386);

            this._portal.v125a5ac74305(false);
            this.RefreshRingHighlight();
            this.PlaceEverything();
        }

        private void Update()
        {
            if (this.v883cb38eaf25 == RoundPhase.Finished || this._popups.va9d0ac8ba808)
            {
                return;
            }

            float delta = Time.deltaTime;

            if (this.v883cb38eaf25 == RoundPhase.Idle)
            {
                this.v2805cf436128 -= delta;
                if (this.v2805cf436128 <= 0f)
                {
                    this.v883cb38eaf25 = RoundPhase.Running;
                }

                this.PlaceEverything();
                return;
            }

            if (this.v883cb38eaf25 == RoundPhase.Diving)
            {
                this.AdvanceDive(delta);
                return;
            }

            this.AdvanceRound(delta);
        }

        private void AdvanceRound(float delta)
        {
            
            
            
            float advance = v7b2cf7ac4b07.v85ce5523d6d5(this.va9b1452c59d9) * delta;

            this.ve5f18ed44c89 += advance;
            this.va9b1452c59d9 += delta;
            this.va7911a4daf47 = v7b2cf7ac4b07.v27238e18d27f(
                this.va7911a4daf47 + (v7b2cf7ac4b07.v443e09775cc6(this.v420488f25267) * advance));

            this.v7ada1d8af2d5 -= delta;

            if (this.vbab7e6960007 > 0f)
            {
                this.vbab7e6960007 -= delta;
            }

            this.CollectStars();
            this.CheckSectors();
            this.PlaceEverything();

            this._hud.v0462b1da3859(this.v7ada1d8af2d5, v2fcef25e0767.v6dff522e9a2e);

            if (this.ve30da349d4d8 > 0f)
            {
                this.ve30da349d4d8 -= delta;
                float offset = this.ve30da349d4d8 > 0f
                    ? Mathf.Sin(this.ve30da349d4d8 * 90f) * this.va45bad433a69.ShakeAmplitude
                    : 0f;
                this._fieldRoot.localPosition = this.vbf51ff0d406e + new Vector3(offset, 0f, 0f);
            }

            if (this.v7ada1d8af2d5 <= 0f)
            {
                this.Lose(v37fff564dbb0.v33449a6cad4a(0));
            }
        }

        private void CollectStars()
        {
            for (int i = 0; i < this.vc363d4a56ef4.Count; i++)
            {
                vf7f1a8d33f1f star = this.vc363d4a56ef4[i];
                if (star.v6e003470ce3e || star.Ring != this.v420488f25267)
                {
                    continue;
                }

                if (v7b2cf7ac4b07.v313a374550cf(this.va7911a4daf47, star.AngleDeg) > v2fcef25e0767.vbf9203b11e1e)
                {
                    continue;
                }

                star.v93e0bcf0d3ec();
                this.v1888f9268bbb++;
                this.v7ada1d8af2d5 = Mathf.Min(
                    this.v7ada1d8af2d5 + v2fcef25e0767.vff26fbb3f4cd, v2fcef25e0767.v6dff522e9a2e);

                this._hud.v9f2343748199(this.v1888f9268bbb, v2fcef25e0767.v19c1a0375d93);
                this._hud.v2c6b5dea1f62();
                this._portal.v125a5ac74305(this.v1888f9268bbb >= v2fcef25e0767.v19c1a0375d93);
            }
        }

        private void CheckSectors()
        {
            bool inside = v2df8a485e3b1.va47d4f337348(
                this.va2c17c6bb56d, this.v420488f25267, this.va7911a4daf47, this.ve5f18ed44c89);

            bool hopping = this.vbab7e6960007 > 0f;
            bool protectedNow = this.va9b1452c59d9 < this.v2a7f2dfd2da4;

            
            if (inside && !this.vef3616525aa1 && !hopping && !protectedNow)
            {
                this.TakeHit();
                inside = false;
            }

            this.vef3616525aa1 = inside;
            this._ball.v927eb4f61510(this.va9b1452c59d9 < this.v2a7f2dfd2da4);
        }

        private void TakeHit()
        {
            this.vd13c7b84ceab--;
            this.v2a7f2dfd2da4 = this.va9b1452c59d9 + v2fcef25e0767.ve04ad6393de6;
            this.ve30da349d4d8 = 0.25f;

            if (this.v420488f25267 > 0)
            {
                this.vdca4c35aedd7 = this.va45bad433a69.RingRadius(this.v420488f25267);
                this.v420488f25267--;
                this.vbab7e6960007 = v2fcef25e0767.vdca2452f0b77;
            }

            this._hud.vde601af15752(this.vd13c7b84ceab);
            this._hud.v78a95eb65a39(this.v420488f25267, v2fcef25e0767.vf7a7d1a4a386);
            this.RefreshRingHighlight();
            this.Burst(va7c9379be56b.v793c5f9ef2be);

            if (this.vd13c7b84ceab <= 0)
            {
                this.Lose(v37fff564dbb0.v33449a6cad4a(1));
            }
        }

        private void OnTapped()
        {
            if (this.v883cb38eaf25 != RoundPhase.Running || this._popups.va9d0ac8ba808)
            {
                return;
            }

            if (this.vbab7e6960007 > 0f || this.va9b1452c59d9 < this.va0c1d67c469d)
            {
                return;
            }

            this.v81f4ec851c85++;

            float gateCentre = v7b2cf7ac4b07.v48d349bd7047(
                this.va2c17c6bb56d.GateStartAngleDeg[this.v420488f25267], v2fcef25e0767.v33b19fbdc041, this.ve5f18ed44c89);

            if (!v7b2cf7ac4b07.v2dd74febdf8a(this.va7911a4daf47, gateCentre, v2fcef25e0767.vdb9f91ca9ce7))
            {
                this.va0c1d67c469d = this.va9b1452c59d9 + v2fcef25e0767.vf5c05b310e6c;
                this._ball.v026bd491211e();
                return;
            }

            this.v5dd6cbf6d171++;
            this.v206d4b7b6d81[this.v420488f25267].v299c8e8c5ef2();
            this.Burst(va7c9379be56b.va10e8b276e1d);

            if (this.v420488f25267 < v2fcef25e0767.vf7a7d1a4a386 - 1)
            {
                this.vdca4c35aedd7 = this.va45bad433a69.RingRadius(this.v420488f25267);
                this.v420488f25267++;
                this.vbab7e6960007 = v2fcef25e0767.vdca2452f0b77;

                this._hud.v78a95eb65a39(this.v420488f25267, v2fcef25e0767.vf7a7d1a4a386);
                this.RefreshRingHighlight();
                return;
            }

            if (this.v1888f9268bbb < v2fcef25e0767.v19c1a0375d93)
            {
                int missing = v2fcef25e0767.v19c1a0375d93 - this.v1888f9268bbb;
                this._hud.v1af27008665e(v37fff564dbb0.v33449a6cad4a(2) + missing + v37fff564dbb0.v33449a6cad4a(3));
                this.va0c1d67c469d = this.va9b1452c59d9 + v2fcef25e0767.vf5c05b310e6c;
                return;
            }

            this.v883cb38eaf25 = RoundPhase.Diving;
            this.vf0d5e8567a4a = v2fcef25e0767.vc2f5b72dd5f0;
            this._input.vb58ed50ae678(false);
        }

        private void AdvanceDive(float delta)
        {
            this.vf0d5e8567a4a -= delta;
            float v6aa337e09394 = 1f - Mathf.Clamp01(this.vf0d5e8567a4a / v2fcef25e0767.vc2f5b72dd5f0);

            float radius = Mathf.Lerp(this.va45bad433a69.RingRadius(this.v420488f25267), 0f, vc0d78983fe6a.vb9b3b3ba8fc5(v6aa337e09394));
            this._ball.v8e8805125499(v6aa337e09394);
            this._ball.v00bf61e06ec1(this.PointAt(radius, this.va7911a4daf47));

            if (this.vf0d5e8567a4a > 0f)
            {
                return;
            }

            this._portal.vb9d7f2bd7053();
            this.Burst(va7c9379be56b.v97a9dfa1067f);
            this.Win();
        }

        private void PlaceEverything()
        {
            for (int vd4a5bb6e81a6 = 0; vd4a5bb6e81a6 < this.v206d4b7b6d81.Count; vd4a5bb6e81a6++)
            {
                this.v206d4b7b6d81[vd4a5bb6e81a6].vfe378af14e7e(v7b2cf7ac4b07.v48d349bd7047(
                    this.va2c17c6bb56d.GateStartAngleDeg[vd4a5bb6e81a6], v2fcef25e0767.v33b19fbdc041, this.ve5f18ed44c89));
            }

            for (int i = 0; i < this.v6782cdaf9592.Count; i++)
            {
                vd4faabe99ed9 v3338e7cccd35 = this.va2c17c6bb56d.Voids[i];
                this.v6782cdaf9592[i].vfe378af14e7e(v7b2cf7ac4b07.v48d349bd7047(
                    v3338e7cccd35.StartAngleDeg, v3338e7cccd35.SpinDegPerSecond, this.ve5f18ed44c89));
            }

            float radius = this.va45bad433a69.RingRadius(this.v420488f25267);
            if (this.vbab7e6960007 > 0f)
            {
                float v6aa337e09394 = 1f - Mathf.Clamp01(this.vbab7e6960007 / v2fcef25e0767.vdca2452f0b77);
                radius = Mathf.Lerp(this.vdca4c35aedd7, radius, vc0d78983fe6a.vb9b3b3ba8fc5(v6aa337e09394));
            }

            this._ball.v00bf61e06ec1(this.PointAt(radius, this.va7911a4daf47));
        }

        private Vector3 PointAt(float radius, float v75bb14d6312e)
        {
            float radians = v75bb14d6312e * Mathf.Deg2Rad;
            return new Vector3(
                this.va45bad433a69.Centre.x + (Mathf.Cos(radians) * radius),
                this.va45bad433a69.Centre.y + (Mathf.Sin(radians) * radius),
                0f);
        }

        private void RefreshRingHighlight()
        {
            for (int vd4a5bb6e81a6 = 0; vd4a5bb6e81a6 < this.v66a35b48c53e.Count; vd4a5bb6e81a6++)
            {
                this.v66a35b48c53e[vd4a5bb6e81a6].v7e850f96fcc3(vd4a5bb6e81a6 == this.v420488f25267);
            }
        }

        private void Burst(Color v391535648d39)
        {
            const int SparkCount = 8;
            Vector3 v07c0b1033342 = this._ball.transform.position;

            for (int i = 0; i < SparkCount; i++)
            {
                vb62326ae72e0 spark = Instantiate(this._sparkPrefab, this._fieldRoot);
                spark.v781425e1fb44(this.va45bad433a69, v07c0b1033342, i * (360f / SparkCount), v391535648d39);
            }
        }

        private void Pause()
        {
            if (this.v883cb38eaf25 == RoundPhase.Finished || this._popups.va9d0ac8ba808)
            {
                return;
            }

            this._input.vb58ed50ae678(false);
            this._popups.v8d8874c184f8(this.v420488f25267, this.v1888f9268bbb, v2fcef25e0767.v19c1a0375d93);
        }

        private void Resume()
        {
            this._popups.v309aafdc7e8c();
            this._input.vb58ed50ae678(this.v883cb38eaf25 == RoundPhase.Running || this.v883cb38eaf25 == RoundPhase.Idle);
        }

        private void Win()
        {
            this.v883cb38eaf25 = RoundPhase.Finished;
            this._input.vb58ed50ae678(false);

            v5e10cba67c40.v8a47a7ab264f(this.v1888f9268bbb);
            this._popups.v939c23489e94(
                this.v1888f9268bbb, v2fcef25e0767.v19c1a0375d93, this.va9b1452c59d9, this.Accuracy());
        }

        private void Lose(string v4bad13dfaf5c)
        {
            if (this.v883cb38eaf25 == RoundPhase.Finished)
            {
                return;
            }

            this.v883cb38eaf25 = RoundPhase.Finished;
            this._input.vb58ed50ae678(false);

            v5e10cba67c40.v8a47a7ab264f(this.v1888f9268bbb);
            this._popups.v3e7f0e5bca8a(
                v4bad13dfaf5c, this.v1888f9268bbb, v2fcef25e0767.v19c1a0375d93, this.v420488f25267, this.Accuracy());
        }

        private string Accuracy()
        {
            if (this.v81f4ec851c85 <= 0)
            {
                return v37fff564dbb0.v33449a6cad4a(4);
            }

            return Mathf.RoundToInt((this.v5dd6cbf6d171 * 100f) / this.v81f4ec851c85) + v37fff564dbb0.v33449a6cad4a(5);
        }

        private void Restart(bool advanceOrbit)
        {
            if (advanceOrbit)
            {
                v5e10cba67c40.v01bf2479bcd0();
            }
            else
            {
                v5e10cba67c40.v9e16b23d80d6();
            }

            this.LoadScene(v28306a333fb7);
        }

        private void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}

internal static class v37fff564dbb0
{
    private const byte v4978b8ba2611 = 0xF7;

    private const string vdb5dda2f1247 = "A200000000016143a37cef91d445a8f5ba";
    private const string v19bdc27ac5d8 = "A200000001411eca5fc153552defe7c894dff2";
    private const string v56c65fa4c0b7 = "A2000000024fbfc3f3b158b1898139d45bfd85b66daa20";
    private const string v4f2ea478d691 = "A2000000031e0c87096368a0d47e88576d060b11";
    private const string v77110e1be4bc = "A200000004660b6a4591";
    private const string vfa2c10904127 = "A200000005cff99211a5";

    internal static string v33449a6cad4a(int id)
    {
        switch (id)
        {
            case 0: return v7a5064aa7f46(vdb5dda2f1247);
            case 1: return v7a5064aa7f46(v19bdc27ac5d8);
            case 2: return v7a5064aa7f46(v56c65fa4c0b7);
            case 3: return v7a5064aa7f46(v4f2ea478d691);
            case 4: return v7a5064aa7f46(v77110e1be4bc);
            case 5: return v7a5064aa7f46(vfa2c10904127);
            default: return string.Empty;
        }
    }

    private static string v7a5064aa7f46(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v4978b8ba2611 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
