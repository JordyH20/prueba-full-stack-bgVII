import { DatePipe } from '@angular/common';
import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Eventos, EventosRequest } from '../../../interface/eventos';
import { EventosRegister as EventosRegisterService } from '../../../services/eventos-register';

@Component({
  imports: [FormsModule, DatePipe],
  selector: 'app-eventos',
  styleUrl: './eventos-register.css',
  templateUrl: './eventos-register.html',
})
export class EventosRegister implements OnInit {
  private servicio = inject(EventosRegisterService);

  registros = signal<Eventos[]>([]);
  cargando = false;
  guardando = false;
  mensaje = '';
  error = '';

  nuevoRegistro: EventosRequest = {
    eventId: 0,
    userId: 0,
    registrationDate: new Date(),
    estado: '',
  };

  ngOnInit(): void {
    this.cargarRegistros();
  }

  cargarRegistros(): void {
    this.cargando = true;
    this.error = '';
    this.servicio.getRegistrosEventos().subscribe({
      next: (registros) => {
        this.registros.set(registros);
        this.cargando = false;
      },
      error: () => {
        this.error = 'No se pudieron cargar los registros.';
        this.cargando = false;
      },
    });
  }

  guardarRegistro(): void {
    this.guardando = true;
    this.mensaje = '';
    this.error = '';

    const solicitud: EventosRequest = {
      ...this.nuevoRegistro,
      registrationDate: new Date(this.nuevoRegistro.registrationDate),
    };

    this.servicio.postEvento(solicitud).subscribe({
      next: () => {
        this.mensaje = 'Registro guardado correctamente.';
        this.nuevoRegistro = {
          eventId: 0,
          userId: 0,
          registrationDate: new Date(),
          estado: '',
        };
        this.guardando = false;
        this.cargarRegistros();
      },
      error: () => {
        this.error = 'No se pudo guardar el registro.';
        this.guardando = false;
      },
    });
  }
}
