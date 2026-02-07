# LC Bhop 🐇

<div align="center">

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Game: Lethal Company](https://img.shields.io/badge/Game-Lethal%20Company-red)](https://store.steampowered.com/app/1966720/Lethal_Company/)

**Choose Language / Выберите язык**
</div>

---

<details open>
<summary><b>🇷🇺 English description (Click to expand)</b></summary>

> 🧩 This mod is based on the [lcbhop](https://github.com/aIIison/lcbhop) project by **aIIison**.
> It implements classic Quake/Half-Life movement physics (CPM) in Lethal Company, completely replacing the standard movement logic [cite: Patches.cs].

## ✨ Features
* **CPM Physics:** Authentic air acceleration and friction from GoldSrc/Source engines [cite: CPMPlayer.cs].
* **Auto-hop:** Hold the jump key for automatic perfect hopping [cite: CPMPlayer.cs].
* **Speedometer:** An interface element (uses the standard Compass) that displays the current horizontal speed [cite: CPMPlayer.cs].
* **Full Freedom:** Disables fall damage and stamina consumption [cite: CPMPlayer.cs].
* **Limit settings:** The “Bunnyhopping” option in the config allows you to remove the speed limit (default 1.7x the maximum) [cite: Config.cs, CPMPlayer.cs].
* **Instant switching:** Turn the mod on and off directly in the match with a single key [cite: CPMPlayer.cs].
* **Wheel jump:** If auto-hop is disabled, the jump is automatically bound to mouse scrolling [cite: Patches.cs].



## 🎮 Controls and Commands
| Action | Input | Description |
| :--- | :--- | :--- |
| **Enable/Disable Mod** | `F1` | Instantly activates or deactivates mod physics |
| **Jump** | `Space` / `Scroll` | Standard jump or mouse wheel (if Auto Bhop is off) |
| **Command: Auto Bhop** | `/autobhop` | Toggle auto-jump mode via chat |
| **Command: Speedometer** | `/speedo` | Hide or show the speedometer |

## 🛠️ Configuration (Movement v4)
Settings are stored in `lcbhop.cfg`. Default values for version v4:
* `Max Speed`: **1500.0** — Horizontal speed limit.
* `Air Accelerate`: **150.0** — Acceleration speed in the air.
* `Gravity`: **800.0** — Standard gravity.
* `Friction`: **4.0** — Friction force against the ground.

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
| **Вкл/Выкл Мод** | `F1` | Мгновенно активирует или деактивирует физику мода |
| **Прыжок** | `Space` / `Scroll` | Стандартный прыжок или колесико мыши (если Auto Bhop выключен) |
| **Команда: Автохоп** | `/autobhop` | Переключить режим авто-прыжка через чат |
| **Команда: Спидометр** | `/speedo` | Скрыть или показать спидометр |

## 🛠️ Конфигурация (Movement v4)
Настройки хранятся в `lcbhop.cfg`. Значения по умолчанию для версии v4:
* `Max Speed`: **1500.0** — Лимит горизонтальной скорости.
* `Air Accelerate`: **150.0** — Скорость набора разгона в воздухе.
* `Gravity`: **800.0** — Стандартная сила тяжести.
* `Friction`: **4.0** — Сила трения о землю.

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
