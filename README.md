# Salud

A personal health-tracking mobile app built with **Xamarin.Forms**, developed as a **university project**. It lets a patient register and keep a history of several health conditions in one place.

> This is an academic/demo project, not a production application. See [Security notes](#security-notes) below before reusing any of this code in a real product.

## Features

- Patient registration and login
- **Diabetes** tracking (blood glucose readings)
- **Hypertension** tracking, with charts and history
- **Hydration** tracking
- **Blood donation** log
- Patient profile

## Tech stack

- [Xamarin.Forms](https://learn.microsoft.com/xamarin/xamarin-forms/) (netstandard2.0) with native **Android** and **iOS** projects
- **MVVM** pattern via `MvvmLightLibsStd10` (`BaseViewModel`, `RelayCommand`)
- **Xamarin.Shell** for navigation and routing
- **SQLite** (`sqlite-net-pcl`) for local persistence
- [Microcharts.Forms](https://github.com/microcharts-dotnet/Microcharts) for charts
- [Syncfusion.Xamarin.SfCalendar](https://www.syncfusion.com/xamarin-ui-controls) for calendar views

## Project structure

```
Salud/Salud/
├── Salud/              # Shared Xamarin.Forms project (Views, ViewModels, Models, DataBase)
├── Salud.Android/      # Android platform project
└── Salud.iOS/          # iOS platform project
```

## Getting started

1. Open `Salud/Salud/Salud.sln` in Visual Studio (with the Xamarin/Mobile development workload).
2. Restore NuGet packages.
3. Set `Salud.Android` or `Salud.iOS` as the startup project and run on an emulator/simulator or device.

A default account (`1` / `1`) is auto-created on first run for quick testing.

## Security notes

Because this was built to demonstrate mobile app development concepts for a university course rather than to ship to real users, a few shortcuts were taken that would need to be fixed before any production use:

- Passwords are stored and compared **in plain text** in the local SQLite database — no hashing.
- A default user (`1` / `1`) is created automatically on first launch.
- Database errors are caught and swallowed rather than surfaced/logged.

## License

No license specified — all rights reserved by the author unless stated otherwise.
