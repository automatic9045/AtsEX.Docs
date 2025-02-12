// 自列車の速度を [m/s] 単位で取得する
double speed = BveHacker.Scenario.VehicleLocation.Speed;

// 自列車を 10 km/h = (10 / 3.6) m/s 加速させる
BveHacker.Scenario.VehicleLocation.SetSpeed(speed + 10 / 3.6);
