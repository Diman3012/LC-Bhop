# LC Bhop

[![Thunderstore](https://img.shields.io/badge/Thunderstore-LC_Bhop_diman3012-blue)](https://thunderstore.io/c/lethal-company/p/SHLUHA/LC_Bhop_diman3012/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](license)
[![Game: Lethal Company](https://img.shields.io/badge/Game-Lethal%20Company-red)](https://store.steampowered.com/app/1966720/Lethal_Company/)
[![BepInEx 5](https://img.shields.io/badge/BepInEx-5.x-green)](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/)

Client-side movement mod for **Lethal Company**. Replaces vanilla movement with classic **Quake / Half-Life CPM physics** — auto-bhop, air strafing, speedometer, and no fall damage.

Based on [lcbhop](https://github.com/aIIison/lcbhop) by **aIIison**.

**[Download on Thunderstore](https://thunderstore.io/c/lethal-company/p/SHLUHA/LC_Bhop_diman3012/)** · **[GitHub](https://github.com/Diman3012/LC-Bhop)**

---

## Features

- **CPM physics** — authentic air acceleration and friction from GoldSrc/Source engines.
- **Auto-bhop** — hold jump for automatic perfect hopping.
- **Air strafing** — gain speed by strafing in the air.
- **Speedometer** — shows current horizontal speed in the compass UI.
- **No fall damage** — fall value is reset while the mod is active.
- **Infinite stamina** — sprint meter stays full.
- **Speed limit toggle** — `Enable bunnyhopping` removes the default speed cap.
- **In-game toggle** — enable or disable mod physics instantly with one key.
- **Scroll jump** — when auto-bhop is off, mouse wheel triggers jump.

## Controls

| Action | Input | Description |
| --- | --- | --- |
| Enable / disable mod | `F1` | Toggle CPM physics on or off |
| Jump | `Space` | Standard jump (or hold for auto-bhop) |
| Jump (alt) | Mouse scroll | Works when auto-bhop is disabled |
| Toggle auto-bhop | `/autobhop` | Chat command |
| Toggle speedometer | `/speedo` | Chat command |

> Mod is **disabled by default**. Press `F1` in-game to enable it.

## Installation

### Thunderstore Mod Manager (recommended)

1. Install [r2modman](https://thunderstore.io/package/ebkr/r2modman/) or [Gale Mod Manager](https://thunderstore.io/c/lethal-company/p/Kastraliss/GaleModManager/).
2. Search for **LC Bhop diman3012** by **SHLUHA**.
3. Install and launch the game through the mod manager.

### Manual

1. Install [BepInEx Pack](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/) for Lethal Company.
2. Download `LC_Bhop.dll` from [Thunderstore](https://thunderstore.io/c/lethal-company/p/SHLUHA/LC_Bhop_diman3012/) or build from source.
3. Place the DLL in:

```text
Lethal Company/BepInEx/plugins/
```

4. Launch the game once to generate the config file.

## Configuration

Config path: `BepInEx/config/lcbhop.cfg`

### General

| Option | Default | Description |
| --- | --- | --- |
| `ModEnabled` | `false` | Global mod toggle (also switched with `F1`) |
| `Auto Bhop` | `true` | Auto-jump while holding Space |
| `Speedometer` | `false` | Show speed in compass UI |

### Movement v4

| Option | Default | Description |
| --- | --- | --- |
| `Enable bunnyhopping` | `true` | Remove speed limit (1.7× cap when off) |
| `Max Speed` | `1500.0` | Horizontal speed limit |
| `Air Accelerate` | `150.0` | Air acceleration |
| `Gravity` | `800.0` | Gravity strength |
| `Friction` | `4.0` | Ground friction |
| `Move Speed` | `250.0` | Base move speed |
| `Accelerate` | `5.0` | Ground acceleration |
| `Jump Force` | `295.0` | Jump force (vanilla: 295) |
| `Stop Speed` | `75.0` | Stop speed threshold |

## Multiplayer

Client-side mod. Other players do not need it installed. Only affects **your** local movement.

## Building from source

Requires **.NET Framework 4.8** and a local Lethal Company install with BepInEx.

1. Open `LC_Bhop.slnx` in Visual Studio or Rider.
2. Update `HintPath` references in `LC_Bhop/LC_Bhop.csproj` to point to your game folder.
3. Build in **Release** configuration.
4. Copy `LC_Bhop/bin/Release/LC_Bhop.dll` to `BepInEx/plugins/`.

## Technical details

- Adds a `CPMPlayer` component to the local player at runtime.
- Patches `CharacterController.Move` to bypass vanilla movement when active.
- Patches `PlayerControllerB.Crouch_performed` for crouch compatibility.
- Hijacks chat submission for `/autobhop` and `/speedo` commands.
- Includes `NetworkPrefabPatch` for Unity Netcode compatibility.

## Credits

- Original [lcbhop](https://github.com/aIIison/lcbhop) by **aIIison**
- Fork and maintenance by **[Diman3012](https://github.com/Diman3012)**

## License

MIT — see [license](license).

---

## Русский

Клиентский мод движения для **Lethal Company**. Заменяет стандартную физику на **Quake / Half-Life CPM** — автохоп, стрейфы в воздухе, спидометр, без урона от падения.

Основан на [lcbhop](https://github.com/aIIison/lcbhop) от **aIIison**.

### Особенности

- **Физика CPM** — ускорение в воздухе и трение как в GoldSrc/Source.
- **Автохоп** — зажми пробел для автоматической распрыжки.
- **Стрейфы** — набор скорости в воздухе.
- **Спидометр** — горизонтальная скорость в интерфейсе компаса.
- **Без урона от падения** и **бесконечная выносливость**.
- **F1** — включить/выключить мод прямо в матче.
- **Колесо мыши** — прыжок, если автохоп выключен.

### Управление

| Действие | Клавиша | Описание |
| --- | --- | --- |
| Вкл/выкл мод | `F1` | Переключить физику мода |
| Прыжок | `Space` / колесо | Прыжок или автохоп |
| Автохоп | `/autobhop` | Команда в чате |
| Спидометр | `/speedo` | Команда в чате |

### Установка

1. Установите [BepInEx Pack](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/).
2. Скачайте мод с [Thunderstore](https://thunderstore.io/c/lethal-company/p/SHLUHA/LC_Bhop_diman3012/) или соберите из исходников.
3. Положите `LC_Bhop.dll` в `Lethal Company/BepInEx/plugins/`.

Конфиг: `BepInEx/config/lcbhop.cfg`

По умолчанию мод **выключен** — нажмите **F1** в игре, чтобы включить.

---

**Author:** [Diman3012](https://github.com/Diman3012) · **Version:** 1.0.0
