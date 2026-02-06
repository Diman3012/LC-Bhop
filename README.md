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
> It implements classic Quake/Half-Life movement physics (CPM) directly into Lethal Company.

## Description
**LC Bhop** is a movement overhaul for **Lethal Company**. It replaces the standard movement system with custom physics, allowing for air strafing, bunnyhopping, and maintaining momentum across the moons.

## ✨ Features
* **CPM Physics:** Authentic Air Accelerate and Friction mechanics from the GoldSrc/Source engines.
* **Auto Bhop:** Hold the jump key to automatically time your jumps perfectly.
* **Speedometer:** A HUD element showing your current horizontal velocity in real-time.
* **Uncapped Speed:** Optional "Bunnyhopping" mode that removes the game's default speed limits.
* **Movement Freedom:** Disables fall damage and provides infinite stamina for an uninterrupted flow.
* **Scroll Jump:** If Auto Bhop is disabled, jumping is automatically remapped to the mouse wheel (compatible with ItemQuickSwitch).
* **Live Commands:** Toggle features using chat commands without restarting the game.

## 🎮 Controls & Commands
| Action | Input | Description |
| :--- | :--- | :--- |
| **Jump** | `Space` / `Scroll` | Standard jump or mouse wheel (if autobhop is OFF) |
| **Toggle Auto Bhop** | `/autobhop` | Chat command to switch between auto and manual jumping |
| **Toggle Speedo** | `/speedo` | Chat command to show or hide the speedometer |

## 🛠️ Installation
1. Install [BepInEx Pack](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/).
2. Download the **lcbhop.dll**.
3. Place the file into `Lethal Company/BepInEx/plugins`.

</details>

---

<details>
<summary><b>🇷🇺 Русское описание (Нажмите, чтобы развернуть)</b></summary>

> 🧩 Этот мод основан на проекте [lcbhop](https://github.com/aIIison/lcbhop) от **aIIison**.
> Он внедряет классическую физику передвижения в стиле Quake/Half-Life (CPM) прямо в Lethal Company.

## Описание
**LC Bhop** — это полная переработка системы передвижения. Мод заменяет стандартную физику на кастомный контроллер, позволяя использовать стрейфы в воздухе, баннихоп и сохранять высокую скорость при перемещении по лунам.

## ✨ Особенности
* **Физика CPM:** Аутентичные механики ускорения в воздухе и трения из движков GoldSrc/Source.
* **Автохоп:** Удерживайте клавишу прыжка для идеальной автоматической распрыжки.
* **Спидометр:** Элемент интерфейса, отображающий вашу текущую горизонтальную скорость.
* **Без лимитов:** Опциональный режим "Bunnyhopping", отключающий стандартные ограничения скорости игры.
* **Полная свобода:** Отключает урон от падения и затраты выносливости для непрерывного движения.
* **Прыжок на колесико:** Если автохоп выключен, прыжок автоматически назначается на прокрутку мыши.
* **Команды в чате:** Переключайте функции мода прямо во время игры через чат.

## 🎮 Управление и команды
| Действие | Ввод | Описание |
| :--- | :--- | :--- |
| **Прыжок** | `Space` / `Колесо` | Обычный прыжок или колесико (если автохоп ВЫКЛ) |
| **Вкл/Выкл Автохоп** | `/autobhop` | Команда в чате для переключения режима прыжков |
| **Вкл/Выкл Спидометр** | `/speedo` | Команда в чате для показа или скрытия спидометра |

## 🛠️ Установка
1. Установите [BepInEx Pack](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/).
2. Скачайте файл **lcbhop.dll**.
3. Поместите файл в папку `Lethal Company/BepInEx/plugins`.

</details>

---

### 🏗️ Technical Details
* **Namespace:** `lcbhop`
* **Hooks:** Patches `CharacterController.Move` for custom velocity control and `PlayerControllerB` for input/crouch fixes.
* **Configuration:** All variables (Gravity, Friction, Max Speed, Accelerate) are adjustable via the `lcbhop.cfg` file.
* **Compatibility:** Designed to work with HUD elements by hijacking the Compass UI for the speedometer.

Created by [Diman3012](https://github.com/Diman3012)
