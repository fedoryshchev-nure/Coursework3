export class SensorDTO {
    constructor (
        public id: string,
        public password: string,
        public isBorken: string,
        public wallId: string
    ) { }
}