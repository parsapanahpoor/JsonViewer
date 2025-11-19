# 🚀 JSON Viewer Component for Blazor

<div align="center">

![JSON Viewer Component](https://raw.githubusercontent.com/JsonViewer-Component/Blazor/main/logo.png)

A powerful, feature-rich JSON viewer component for Blazor applications with VS Code-style syntax highlighting.

[![NuGet Version](https://img.shields.io/nuget/v/JsonViewer.Blazor?style=flat-square&logo=nuget)](https://www.nuget.org/packages/JsonViewer.Blazor/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/JsonViewer.Blazor?style=flat-square&logo=nuget)](https://www.nuget.org/packages/JsonViewer.Blazor/)
[![GitHub Stars](https://img.shields.io/github/stars/JsonViewer-Component/Blazor?style=flat-square&logo=github)](https://github.com/JsonViewer-Component/Blazor)
[![License](https://img.shields.io/github/license/JsonViewer-Component/Blazor?style=flat-square)](https://github.com/JsonViewer-Component/Blazor/blob/main/LICENSE)

[Demo](https://jsonviewer-component.github.io/Blazor/) | [Documentation](https://github.com/JsonViewer-Component/Blazor#readme) | [Report Bug](https://github.com/JsonViewer-Component/Blazor/issues) | [Request Feature](https://github.com/JsonViewer-Component/Blazor/issues)

</div>

---

## ✨ Features

- 🎨 **VS Code-style** syntax highlighting
- 🌓 **Dark & Light** theme support with persistence
- 🔍 **Real-time search** with match highlighting and navigation
- 📊 **JSON statistics** (size, depth, type distribution)
- 📝 **Edit mode** with auto-formatting and validation
- 📋 **Copy & Export** functionality
- ⌨️ **Keyboard shortcuts** (Enter, Shift+Enter for search navigation)
- 🔢 **Line numbers** with active line highlighting
- 🎯 **Expand/Collapse** individual or all nodes
- 📱 **Fully responsive** design for mobile, tablet, and desktop
- ⚡ **High performance** - handles large JSON files efficiently
- 🎭 **Smooth animations** and transitions

---

## 📦 Installation

Install via NuGet Package Manager:
```bash
dotnet add package JsonViewer.Blazor
```
Or via Package Manager Console:

```powershell
Install-Package JsonViewer.Blazor
```
---

## 🚀 Quick Start

### 1️⃣ Add namespace to `_Imports.razor`:

```razor
@using JsonViewerComponent
@using JsonViewerComponent.Components
```
### 2️⃣ Use in your component:

```razor
@page "/json-demo"

<JsonViewer JsonData="@jsonString" IsEditable="true" />

@code {
private string jsonString = @"{
""name"": ""John Doe"",
""age"": 30,
""email"": ""john.doe@example.com"",
""hobbies"": [""reading"", ""gaming"", ""coding""]
}";
}
```
---

## 📖 Usage Examples

### Read-Only Mode

```razor
<JsonViewer JsonData="@jsonData" IsEditable="false" />
```
### Editable Mode with Two-Way Binding

```razor
<JsonViewer @bind-JsonData="jsonData" IsEditable="true" />

@code {
private string jsonData = "{}";
}
```
### Dynamic JSON Loading

```razor
<button @onclick="LoadSampleData">Load Sample</button>
<JsonViewer JsonData="@jsonData" IsEditable="true" />

@code {
private string jsonData = "";

private void LoadSampleData()
{
jsonData = @"{""userId"": 1, ""userName"": ""Alice""}";
}
}
```
---

## ⌨️ Keyboard Shortcuts

| Shortcut | Action |
|----------|--------|
| `Enter` | Navigate to next search match |
| `Shift + Enter` | Navigate to previous search match |
| `Escape` | Clear search (when search is active) |

---

## 🎨 Theme Support

The component automatically saves your theme preference to localStorage:

```razor
@* Theme persists across page refreshes *@
<JsonViewer JsonData="@jsonData" IsEditable="true" />
```
---

## 📊 JSON Statistics

View detailed statistics about your JSON:

- **Total Size** (bytes)
- **Total Properties**
- **Object Count**
- **Array Count**
- **Max Depth**
- **Average Array Length**

Access statistics via the stats button in the sidebar.

---

## 🔍 Search Features

- **Real-time highlighting** of all matches
- **Match counter** showing current match / total matches
- **Navigation buttons** to jump between matches
- **Keyboard support** for quick navigation
- **Case-insensitive** search

---

## 🛠️ Configuration

Currently, the component works out-of-the-box with minimal configuration. Future versions will support:

- Custom themes
- Plugin system
- Additional export formats
- And more!

---

## 🤝 Contributing

We welcome contributions! Here's how you can help:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

Please read our [Contributing Guide](https://github.com/JsonViewer-Component/Blazor/blob/main/CONTRIBUTING.md) for more details.

---

## 🐛 Bug Reports & Feature Requests

Found a bug or have an idea? Please open an issue:

- [Report a Bug](https://github.com/JsonViewer-Component/Blazor/issues/new?labels=bug)
- [Request a Feature](https://github.com/JsonViewer-Component/Blazor/issues/new?labels=enhancement)

---

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/JsonViewer-Component/Blazor/blob/main/LICENSE) file for details.

---

## 💖 Support

If you find this project helpful, please consider:

- ⭐ **Starring** the repository
- 🐛 **Reporting bugs** or **suggesting features**
- 📢 **Sharing** with others
- ☕ **Sponsoring** the project

---

## 👨‍💻 Author

**Parsa Panahpoor**

- GitHub: [@parsapanahpoor](https://github.com/parsapanahpoor)
- Website: [Your Website](https://your-website.com)

---

## 🌟 Acknowledgments

Special thanks to all contributors and the Blazor community!

---

<div align="center">

Made with ❤️ by [JsonViewer Component](https://github.com/JsonViewer-Component)

</div>


---
