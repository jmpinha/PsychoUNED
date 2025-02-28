import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';

@Injectable({
    providedIn: 'root'
})
export class GlobalsService {

    constructor(private toastController: ToastController) { }

    async showToast(word: string) {
        const toast = await this.toastController.create({
            message: word,
            duration: 3000,
            position: 'bottom'
        });

        await toast.present();
    }
    public loadLetter(i: number): string {
        return `${String.fromCharCode(97 + i)})`
    }
    public roundUpTwoDecimals(value: number): number {
        return Math.ceil(value * 100) / 100;
    }
    public roundDownTwoDecimals(value: number): number {
        return Math.floor(value * 100) / 100;
    }
}
