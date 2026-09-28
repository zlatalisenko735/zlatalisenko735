# Generation notes

Read this before the design document in `prompts/` — the document was written against a
different template than the one attached to this ticket, and the build followed the template
that is actually here.

## What the attached template turned out to be

Nothing the standard flow assumes was present: no `BASE_PANEL` / `BASE_POP` / `BASE_BUTTON`,
no `SETTINGS`, no `PanelController` / `PopsController` / `BasicController` / `InputController`,
no `1_MenuScene`, and no DOTween. What it ships is a 2D URP project with two registered scenes
and three scripts (`ControllerMenu`, `ControllerPrivacyPolicy`, `PanelsFlow`).

It also arrived with defects that would have shipped as visible bugs:

| Defect | Where | What it looks like on device |
|---|---|---|
| `PanelGame` root: a pin-board from another game | `Loader.unity` | 32 buttons with no handler, ~20 Images bound to sprite guids that are in no `.meta` — each one draws as a solid white rectangle |
| `ControllerGame`, `BallTouch` scripts referenced, `.cs` files absent | `Loader.unity` | missing-script components |
| `SceneWarmup`, `HelpOverlay` scripts referenced, `.cs` files absent | `Loader.unity` (`Main` root) | missing-script components |
| Slider `Background` and `Fill` bound to missing sprite guids | `Loader.unity` | white rectangles where the loading bar should be |
| Every TMP label bound to a font asset guid that is in no `.meta` | `Loader.unity` | no glyphs |
| UI input module bound to input-actions guid `ca9f5fa9…`, absent | both scenes | **no button in the app responds to a tap** |
| Camera framed 32 world units | `2_GameScene.unity` | – |

## What was done about it

* **`PanelGame` and `Main` were deleted** rather than re-dressed. The game belongs in its own
  scene, and a pin-board driven by two missing scripts is not this game's furniture.
* `PanelsFlow` (the tri-panel director that toggles Menu / Loader / Game roots inside one scene)
  was taken off `SceneFlow`, and `ControllerMenu` off `menu` — its Play handler switched to the
  deleted `PanelGame`. Both `.cs` files are untouched on disk.
* Missing sprite bindings were re-pointed at the built-in rounded UI sprite or cleared.
* Every TMP label now uses `Assets/TextMesh Pro/.../LiberationSans SDF.asset`, the font asset
  that is actually in this project, whose material is themed to the palette (OUTLINE_ON,
  outline `#060B1A` at 0.46, face dilate 0.44).
* The UI input module in both scenes now points at `Assets/Settings/InputSystem_Actions.inputactions`.
* `Button_privacy` is deactivated and its missing sprite cleared: no policy URL exists at
  generation time, and a button whose only effect is an error in the log is a dead button.
  `ControllerPrivacyPolicy` is left in place on `menu` for whoever has the URL.

## Layout of the delivered app

* **Build index 0 — `Assets/Scenes/Loader.unity`.** Loading panel (abstract orbit mark, themed
  progress bar, `CHARTING ORBITS`) for four seconds, then the menu: mark, objective, star bank,
  `PLAY`, `ORBIT 01…04`, `HOW TO PLAY` and its overlay. Driven by `MenuSceneDirector`.
* **Build index 1 — `Assets/Scenes/Games/2_GameScene.unity`.** The whole game. Driven by
  `OrbitFieldDirector`; moving between scenes is `SceneManager.LoadScene(<index>)`, never by name.

## Deviations from the design document, and why

* **No DOTween** — it is not in the project and no UPM dependency was added. The animations the
  document calls for are written against `Easing` and per-frame interpolation instead.
* **Dark sectors chase the ball instead of drifting against it.** The document's
  `VOID_SPIN = 15 * (1 + 0.12i)` makes a 70-degree sector sweep across a ball orbiting at
  40–72 deg/s every five to eleven seconds, which turns every ring into a coin flip that no
  amount of skill avoids — the ball cannot leave its track except through a gate. Sectors now
  travel the same way as the ball at 0.45–0.86 of its speed, so each one is a visible deadline
  closing in. This is what makes the ring solvable by construction; see
  `OrbitLayoutGenerator`.
* **Ring dwell is measured in laps, not seconds.** A ball on a circular track passes every angle
  once per lap, so stars "placed at t = 14 s" are collected on the first lap regardless. The
  generator works in laps for that reason.
* **The star quota shown in the menu is the real one** (12). The document's per-preset quotas of
  13 and 14 would have required collecting every star placed.
* **No app icon** was generated: this ticket builds nothing and ships no store listing.

## Checks that were run

* `Assets/Scripts/Generated/*.cs` compiles clean under Roslyn against the Unity 6 assemblies
  (`CS0649` on `[SerializeField]` fields only, which Unity suppresses).
* The layout generator was ported to a scratch harness and run over 160 seeds: every one
  produced a solvable orbit, so the hard-coded fallback never fires.
* A static pass over both scenes and all five prefabs confirms: guids unique, every asset
  reference resolves, no null scripts, no unset serialized field, 13 live buttons all driven,
  every sprite renderer inside `-29..-1`, every label ASCII with autosize on, word wrap off and
  `fontSizeMin` above the readability floor.
