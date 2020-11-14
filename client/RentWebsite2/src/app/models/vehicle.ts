export class Vehicle {
    public constructor(public vehicleID?: number,
        public vehicleTypeID?: number,
        public mileage?: number,
        public rentingProper?: number,
        public rentingAvailibility?: number,
        public registrationNumber?: number,
        public branchID?: number,
        public image?: string,
        public manufacturer?: string,
        public model?: string,
        public branchName?: string,
        public productionYear?: number,
        public gear?: string,
    ){}
}