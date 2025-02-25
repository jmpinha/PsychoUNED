import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root'
})
export class GlobalsService {

  constructor(private toastController: ToastController) { }

  async showToast(word: string) {
    const toast = await this.toastController.create({
      message: `Este es un mensaje flotante ${word}`,
      duration: 3000,  // Se muestra por 3 segundos
      position: 'bottom' // Puedes usar 'top', 'middle' o 'bottom'
    });

    await toast.present();
  }
}
