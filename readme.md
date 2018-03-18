# Запуск
* 1 аргумент - адрес
* 2 аргумент (необязательный) - максимальное число хопов

__Сбилженая версия лежит по пути ./AS-Route/bin/Release/__
_что-то как-то по-дурацки сначала назвал его роутером, а не трейсером, а теперь солюшн не переименовать_

## Пример вывода
```
/Users/Yewert/Documents/AS-Route/AS-Route/bin/Release/AS_Route.exe www.defence.go.ug

Tracing route to www.defence.go.ug [154.72.196.195]
over a maximum of 30 hops:

  1     1 ms     1 ms     1 ms  Dlink-Router.Dlink [192.168.0.1]
Unsuccessful request: private range
  2     2 ms     2 ms     2 ms  10.84.255.254
Unsuccessful request: private range
  3     2 ms     1 ms     1 ms  lag-3-438.bgw01.ekat.ertelecom.ru [109.195.104.30]
Address: 109.195.104.30, Country: Russia, AutonomousSystem: AS51604 JSC ER-Telecom Holding, InternetServiceProvider: JSC ER-Telecom Holding
  4    22 ms    22 ms    22 ms  ertelekom-ic-313399-mow-b4.c.telia.net [62.115.12.110]
Address: 62.115.12.110, Country: Sweden, AutonomousSystem: AS1299 Telia Company AB, InternetServiceProvider: Telia Company
  5    22 ms    22 ms    22 ms  ae10-153.RT1.M9.MSK.RU.retn.net [87.245.254.153]
Address: 87.245.254.153, Country: Russia, AutonomousSystem: AS9002 RETN Limited, InternetServiceProvider: RETN Limited
  6    77 ms    58 ms    59 ms  ae3-4.RT.EQX.FKT.DE.retn.net [87.245.232.233]
Address: 87.245.232.233, Country: United States, AutonomousSystem: AS9002 RETN Limited, InternetServiceProvider: RETN Limited
  7    62 ms    72 ms    91 ms  decix.seacom.mu [80.81.193.237]
Address: 80.81.193.237, Country: Germany, AutonomousSystem: AS47872 Sofia Connect EAD, InternetServiceProvider: DE-CIX Management GmbH
  8   207 ms   207 ms   207 ms  ae-5-0.er-01-fra.de.seacomnet.com [105.16.9.21]
Address: 105.16.9.21, Country: Mauritius, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
  9   209 ms   207 ms   210 ms  xe-0-0-0-1.cr-01-mrs.fr.seacomnet.com [105.16.12.157]
Address: 105.16.12.157, Country: Mauritius, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
 10   206 ms   207 ms   207 ms  xe-0-1-0-1.cr-01-mba.ke.seacomnet.com [105.16.8.10]
Address: 105.16.8.10, Country: Mauritius, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
 11   208 ms   207 ms   207 ms  105.16.13.41
Address: 105.16.13.41, Country: Mauritius, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
 12   207 ms   209 ms   206 ms  xe-0-0-0-0.er-01-ebb.ug.seacomnet.com [105.16.11.154]
Address: 105.16.11.154, Country: Mauritius, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
 13   205 ms   206 ms   205 ms  xe-0-1.es-03-ebb.ug.seacomnet.com [105.16.8.98]
Address: 105.16.8.98, Country: Mauritius, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
 14   206 ms   206 ms   205 ms  105.21.80.34
Address: 105.21.80.34, Country: Uganda, AutonomousSystem: AS37100 SEACOM-AS, InternetServiceProvider: Seacom
 15   206 ms   205 ms   205 ms  h9.gou.go.ug [154.72.208.9]
Address: 154.72.208.9, Country: Uganda, AutonomousSystem: AS327724 NITA, InternetServiceProvider: National Information Technology Authority Uganda
 16     *        *        *     Request timed out.
 17     *        *        *     Request timed out.
 18     *        *        *     Request timed out.
 19     *        *        *     Request timed out.
 20     *        *        *     Request timed out.
 21     *        *        *     Request timed out.
 22     *        *        *     Request timed out.
 23     *        *        *     Request timed out.
 24     *        *        *     Request timed out.
 25     *        *        *     Request timed out.
 26     *        *        *     Request timed out.
 27     *        *        *     Request timed out.
 28     *        *        *     Request timed out.
 29     *        *        *     Request timed out.
 30     *        *        *     Request timed out.

Trace complete.

```
