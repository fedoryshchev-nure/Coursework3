import { MaterialDTO } from "app/walls-state/dtos/material-dto";

export class CreateWallDTO {
    constructor(
        public sensorCount: number,
        public material: MaterialDTO
    ) {}
}