# maui-listview-performance-metrics

Performance benchmark samples, benchmark results, and test environment documentation for the .NET MAUI ListView control across Android, iOS, Windows, and macOS. These benchmarks enable reproducible performance validation for loading, grouping, filtering, sorting, and scrolling operations across supported platforms.

## Test Setup

| Item | Details |
|--------|---------|
| Version | Syncfusion .NET MAUI v35.1.39 |
| Android Device | Vivo V2355, Android 16 |
| Windows Device | ASUS Vivobook |
| iOS Device | iPhone 18 Pro, iOS 27.0 |
| macOS Device | Mac mini (Apple M4 Pro) |
| Build Configuration | Release, .NET 10 |
| Tested Date | October 9, 2026 |

## ListView Item Loading Performance

| Use Case | Windows | Android | macOS | iOS |
|-----------|---------:|---------:|---------:|---------:|
| 100 Items Loading | 326 | 1965 | 547 | 446 |
| 1,000 Items Loading | 338 | 1617 | 540 | 411 |
| 10K Items Loading | 381 | 1973 | 549 | 441 |
| 1L Items Loading | 395 | 2199 | 605 | 487 |
| 10L Items Loading | 698 | 4401 | 1234 | 1088 |

## ListView Item Grouping Performance

| Use Case | Windows | Android | macOS | iOS |
|-----------|---------:|---------:|---------:|---------:|
| 100 Grouping | 355 | 1302 | 434 | 344 |
| 1,000 Grouping | 368 | 1689 | 446 | 360 |
| 10K Grouping | 419 | 1921 | 609 | 538 |
| 1L Grouping | 631 | 4301 | 2286 | 2170 |
| 10L Grouping | 2343 | 28950 | 19543 | 18728 |

## ListView Item Filtering Performance

| Use Case | Windows | Android | macOS | iOS |
|-----------|---------:|---------:|---------:|---------:|
| 100 Filtering | 88 | 1978 | 46 | 76 |
| 1,000 Filtering | 22 | 208 | 65 | 81 |
| 10K Filtering | 21 | 222 | 115 | 127 |
| 1L Filtering | 72 | 593 | 593 | 605 |
| 10L Filtering | 139 | 4972 | 5087 | 5179 |

## ListView Item Sorting Performance

| Use Case | Windows | Android | macOS | iOS |
|-----------|---------:|---------:|---------:|---------:|
| 100 Sorting | 374 | 2093 | 553 | 473 |
| 1,000 Sorting | 363 | 2089 | 570 | 468 |
| 10K Sorting | 409 | 2099 | 726 | 523 |
| 1L Sorting | 621 | 3068 | 2795 | 1058 |
| 10L Sorting | 1100 | 12970 | 27755 | 7264 |

## ListView Item Scrolling Performance

### 100 Items

| Platform | Without Animation | With Animation |
|----------|------------------:|---------------:|
| Windows | 2247 | 2464 |
| Android | 4550 | 8837 |
| macOS | 2649 | 2491 |
| iOS | 1973 | 2381 |

### 1,000 Items

| Platform | Without Animation | With Animation |
|----------|------------------:|---------------:|
| Windows | 3341 | 4318 |
| Android | 4834 | 4647 |
| macOS | 3088 | 2742 |
| iOS | 1838 | 3076 |

### 10K Items

| Platform | Without Animation | With Animation |
|----------|------------------:|---------------:|
| Windows | 2391 | 3094 |
| Android | 2247 | 4605 |
| macOS | 2434 | 3129 |
| iOS | 1726 | 3266 |

### 1L Items

| Platform | Without Animation | With Animation |
|----------|------------------:|---------------:|
| Windows | 3258 | 2779 |
| Android | 3341 | 5107 |
| macOS | 2572 | 2354 |
| iOS | 2289 | 2887 |

### 10L Items

| Platform | Without Animation | With Animation |
|----------|------------------:|---------------:|
| Windows | 3986 | 3441 |
| Android | 3341 | 6308 |
| macOS | 3055 | 3439 |
| iOS | 2910 | 3491 |

## Notes

- All benchmarks were executed using the **Release** configuration on **.NET 10**.
- Results were collected on physical devices across Android, iOS, Windows, and macOS platforms.
- Values represent execution times captured during benchmark runs and are intended for comparative analysis.
- Performance may vary based on device hardware, operating system version, and runtime conditions.
