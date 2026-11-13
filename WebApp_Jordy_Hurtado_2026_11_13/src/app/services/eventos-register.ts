import { inject, Injectable } from '@angular/core';
import { environment } from '../../enviroment';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Eventos, EventosRequest } from '../interface/eventos';


@Injectable({
    providedIn: 'root'
})
export class EventosRegister {
    private url =  `${environment.apiUrl}/RegistroEventosControllers`; 
    private http = inject(HttpClient);

    getRegistrosEventos(): Observable<Eventos[]> {
        return this.http.get<Eventos[] | Eventos>(this.url).pipe(
            map((respuesta) => Array.isArray(respuesta) ? respuesta : [respuesta])
        );
    }

    postEvento(evento: EventosRequest): Observable<unknown> {
        return this.http.post<unknown>(this.url, evento);
    }

}
