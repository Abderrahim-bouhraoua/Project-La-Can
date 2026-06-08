# ⛴️ Project La Can

> Console application in **C#** for managing ferry reservations between **Lorient, Groix, Quiberon and Belle-Île**.

---

## 🚀 About the Project

**Project La Can** is a C# console application that simulates a ferry reservation system.

The user can choose a ferry route, select a travel date and departure time, add passengers, add vehicles, calculate the total price, and generate a reservation file in JSON format.

This project was created as a first-year **BUT Informatique** school project.

---

## ✨ Main Features

* 🛳️ Choose between 4 ferry routes
* 📅 Select a day in November 2025
* 🕒 Load available departure times from a CSV file
* 👤 Add passengers with different categories
* 🚗 Add vehicles with different categories and prices
* 💰 Calculate the final reservation price
* 📋 Display a complete reservation summary
* 🧾 Generate a `reservation.json` file
* ✅ Input validation to avoid invalid choices

---

## 🌍 Available Routes

The application manages 4 possible journeys:

| ID | Route                |
| -- | -------------------- |
| 1  | Lorient → Groix      |
| 2  | Groix → Lorient      |
| 3  | Quiberon → Belle-Île |
| 4  | Belle-Île → Quiberon |

---

## 🧑‍🤝‍🧑 Passenger Categories

| Code      | Category               |
| --------- | ---------------------- |
| `adu26p`  | Adult                  |
| `jeu1825` | Young passenger        |
| `enf417`  | Child                  |
| `bebe`    | Baby                   |
| `ancomp`  | Pet / animal companion |

---

## 🚗 Vehicle Categories

The program also supports vehicle reservations, including:

* Scooter / trottinette
* Bike
* Electric bike
* Motorcycle
* Cars by size category
* Camper van

Each category has its own code and price depending on the destination.

---

## 🛠️ Technologies Used

| Technology       | Usage                     |
| ---------------- | ------------------------- |
| **C#**           | Main programming language |
| **Console App**  | User interface            |
| **CSV**          | Departure times storage   |
| **JSON**         | Reservation export        |
| **Git / GitHub** | Version control           |

---

## 📂 Project Structure

```text
Project-La-Can/
│
├── Main.cs              # Main source code
├── horaires.csv         # Ferry departure times
├── reservation.json     # Generated reservation file
├── LICENSE              # MIT License
└── README.md            # Project documentation
```

---
## 📦 Installation

### 1. Clone the repository

```bash
git clone https://github.com/USERNAME/Project-La-Can.git
```

Then open the folder:

```bash
cd Project-La-Can
```

---

### 2. Make sure the CSV file is present

The file `horaires.csv` must stay in the same folder as `Main.cs` or in the execution directory.

It contains the available departure times used by the program.

---

### 3. Compile the project

With the .NET SDK:

```bash
dotnet new console
dotnet run
```

Or compile directly with a C# compiler:

```bash
csc Main.cs
```

Then run:

```bash
Main.exe
```
---

## 🧠 How It Works

The program starts by asking the user for a reservation name.

Then the user chooses:

1. A ferry route
2. A travel day
3. A departure time
4. Passengers
5. Vehicles

After that, the program displays a full summary and calculates the total price.

Finally, the reservation is saved into a JSON file.

---

## 📄 JSON Output Example

```json
{
  "reservation": {
    "nom": "ReservationTest",
    "idLiaison": 3,
    "date": "2025-11-03",
    "heure": "11:15"
  },
  "passagers": [
    {
      "nom": "Dupont",
      "prenom": "Jean",
      "codeCategorie": "adu26p"
    }
  ],
  "vehicules": [
    {
      "codeCategorie": "velo",
      "quantite": 1
    }
  ]
}
```

---

## 🎯 Project Goal

The goal of this project was to practice core programming concepts in C#:

* variables and data structures
* lists and dictionaries
* functions
* file reading with CSV
* manual JSON generation
* input validation
* console interaction
* project organization

---

## 👤 Author

Created by:

* **Abderrahim BOUHRAOUA**

---

## 📄 License

This project is licensed under the **MIT License**.
See the [LICENSE](LICENSE) file for more details.

---

## ⛴️ Project La Can

<p align="center">
  <strong>Book your crossing. Choose your route. Sail away.</strong>
</p>
