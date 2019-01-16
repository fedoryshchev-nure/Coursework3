import { SensorDTO } from "app/admin/models/sensor-dto";
import { MaterialDTO } from "./material-dto";

export class WallDTO {
    constructor(
        public id: string,
        public wallSensors: SensorDTO[],
        public material: MaterialDTO
    ) {}
}