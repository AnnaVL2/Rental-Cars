export class User {
    public constructor(public userID?: number,
                        public roleID?: number,
                        public roleTitle?: string,
                        public firstName?: string,
                        public lastName?: string,
                        public userIDNumber?: number,
                        public userName?: string,
                        public birthDate?: number,
                        public gender?: string,
                        public email?: string,
                        public password?: number,
                        public image?: string) {
    }
}