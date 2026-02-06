# LC Bhop 🐇

<div align="center">

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Game: Lethal Company](https://img.shields.io/badge/Game-Lethal%20Company-red)](https://store.steampowered.com/app/1966720/Lethal_Company/)

**Choose Language / Выберите язык**
</div>

---

<details open>
<summary><b>🇬🇧 English Description (Click to expand)</b></summary>

> 🧩 This mod is based on [lcbhop](https://github.com/aIIison/lcbhop) by **aIIison**.
> It implements classic Quake/Half-Life movement physics (CPM) directly into Lethal Company by overriding the default character controller [cite: Patches.cs].

## ✨ Features
* **CPM Physics:** Authentic Air Accelerate and Friction mechanics from the GoldSrc/Source engines [cite: CPMPlayer.cs].
* **Auto Bhop:** Hold the jump key to automatically time your jumps perfectly [cite: CPMPlayer.cs].
* **Speedometer:** A HUD element (repurposed Compass UI) showing your horizontal velocity in real-time [cite: CPMPlayer.cs].
* **Movement Freedom:** Disables fall damage and provides infinite stamina for an uninterrupted flow [cite: CPMPlayer.cs].
* **Dynamic Speed Cap:** Optional "Bunnyhopping" mode in config to remove or scale the game's default speed limits [cite: Config.cs, CPMPlayer.cs].
* **Toggleable:** Enable or disable the mod instantly with a hotkey [cite: CPMPlayer.cs].
* **Scroll Jump:** If Auto Bhop is disabled, jumping is remapped to the mouse wheel (ideal for use with `ItemQuickSwitch`) [cite: Patches.cs].

## 🎮 Controls & Commands
| Action | Input | Description |
| :--- | :--- | :--- |
| **Toggle Mod** | `F1` | Completely enable/disable the mod physics and HUD in-game [cite: CPMPlayer.cs] |
| **Jump** | `Space` / `Scroll` | Standard jump or mouse wheel (if Auto Bhop is OFF) [cite: CPMPlayer.cs, Patches.cs] |
| **Toggle Auto Bhop** | `/autobhop` | Chat command to switch jump modes [cite: Patches.cs] |
| **Toggle Speedo** | `/speedo` | Chat command to show/hide the speedometer [cite: Patches.cs] |

## 🛠️ Configuration
All movement variables can be adjusted in `lcbhop.cfg` [cite: Config.cs]:
* `Gravity`: Default 800.0 [cite: Config.cs]
* `Friction`: Default 4.0 [cite: Config.cs]
* `Max Speed`: Max horizontal speed per tick (320.0) [cite: Config.cs]
* `Air Accelerate`: Default 10.0 [cite: Config.cs]
* `Enable bunnyhopping`: Set to `true` to remove the 1.7x speed cap [cite: Config.cs].

</details>

---

<details>
<summary><b>🇷🇺 Русское описание (Нажмите, чтобы развернуть)</b></summary>

> 🧩 Этот мод основан на проекте [lcbhop](https://github.com/aIIison/lcbhop) от **aIIison**.
> Он внедряет классическую физику передвижения Quake/Half-Life (CPM) в Lethal Company, полностью заменяя стандартную логику перемещения [cite: Patches.cs].

## ✨ Особенности
* **Физика CPM:** Аутентичное ускорение в воздухе и трение из движков GoldSrc/Source [cite: CPMPlayer.cs].
* **Автохоп:** Удерживайте клавишу прыжка для автоматической идеальной распрыжки [cite: CPMPlayer.cs].
* **Спидометр:** Элемент интерфейса (использует стандартный Компас), отображающий текущую горизонтальную скорость [cite: CPMPlayer.cs].
* **Полная свобода:** Отключает урон от падения и затраты выносливости [cite: CPMPlayer.cs].
* **Настройка лимитов:** Опция "Bunnyhopping" в конфиге позволяет снять ограничение скорости (по умолчанию 1.7x от максимальной) [cite: Config.cs, CPMPlayer.cs].
* **Мгновенное переключение:** Включение и выключение мода прямо в матче одной клавишей [cite: CPMPlayer.cs].
* **Прыжок на колесико:** Если автохоп выключен, прыжок автоматически биндится на прокрутку мыши [cite: Patches.cs].

## 🎮 Управление и команды
| Действие | Ввод | Описание |
| :--- | :--- | :--- |
| **Вкл/Выкл Мод** | `F1` | Полное включение/выключение физики и спидометра [cite: CPMPlayer.cs] |
| **Прыжок** | `Space` / `Колесо` | Прыжок или колесико мыши (если Автохоп ВЫКЛ) [cite: CPMPlayer.cs, Patches.cs] |
| **Переключить Автохоп** | `/autobhop` | Команда в чате для смены режима прыжков [cite: Patches.cs] |
| **Переключить Спидометр** | `/speedo` | Команда в чате для показа/скрытия скорости [cite: Patches.cs] |

## 🛠️ Настройка
Параметры движения настраиваются в файле `lcbhop.cfg` [cite: Config.cs]:
* `Gravity`: Гравитация (стандарт: 800.0) [cite: Config.cs]
* `Friction`: Трение о землю (стандарт: 4.0) [cite: Config.cs]
* `Max Speed`: Максимальная скорость за тик (стандарт: 320.0) [cite: Config.cs]
* `Air Accelerate`: Ускорение в воздухе (стандарт: 10.0) [cite: Config.cs]
* `Enable bunnyhopping`: Установите `true`, чтобы снять ограничение скорости в 1.7x [cite: Config.cs].

</details>

---

### 🏗️ Technical Implementation
* **Core Logic:** The mod adds a custom `CPMPlayer` component to the local player object [cite: Plugin.cs].
* **Hooks:**
    * Prefixes `CharacterController.Move` to bypass vanilla movement when the mod is active [cite: Patches.cs].
    * Patches `PlayerControllerB.Crouch_performed` to fix crouching behavior with custom physics [cite: Patches.cs].
    * Hijacks `HUDManager` chat submission to handle custom commands [cite: Patches.cs].
* **UI:** Uses `TextMeshProUGUI` found in the game's Compass UI to display the speedometer [cite: CPMPlayer.cs].
* **Networking:** Includes a `NetworkPrefabPatch` to ensure compatibility with the game's network manager [cite: Plugin.cs].

**Created by [Diman3012](https://github.com/Diman3012)**
