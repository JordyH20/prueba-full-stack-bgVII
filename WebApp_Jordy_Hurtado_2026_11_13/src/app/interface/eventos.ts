export interface Eventos {
     registrationId: number;
     eventId: number;
     userId: number;
     registrationDate: Date;
     estado: string;

}

export interface EventosRequest {
    eventId: number;
    userId: number;
    registrationDate: Date;
    estado: string;
}