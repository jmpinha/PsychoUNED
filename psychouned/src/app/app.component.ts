
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { IonApp, IonSplitPane, IonMenu, IonContent, IonList, IonListHeader, IonNote, IonMenuToggle, IonItem, IonIcon, IonLabel, IonRouterOutlet, IonRouterLink } from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { flowerOutline, bookOutline, checkboxOutline, calculatorOutline } from 'ionicons/icons';
import { MenuNames } from './models/Names';
import { MatIconModule } from '@angular/material/icon';

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.scss'],
    imports: [RouterLink, RouterLinkActive, IonApp, IonSplitPane, IonMenu, IonContent, IonList, IonListHeader, IonNote, IonMenuToggle, IonItem, IonIcon, IonLabel, IonRouterLink, IonRouterOutlet,
        MatIconModule
    ],
})
export class AppComponent {
    public appPages = [
        { title: MenuNames.SUBJECTS, url: 'subjects', icon: 'flower' },
        { title: MenuNames.NOTES, url: 'notes', icon: 'book' },
        { title: MenuNames.TESTS, url: 'tests', icon: 'checkbox' },
        { title: MenuNames.GRADES, url: 'grades', icon: 'calculator' },
    ];
    public labels = ['Family', 'Friends', 'Notes', 'Work', 'Travel', 'Reminders'];
    constructor() {
        addIcons({ flowerOutline, bookOutline, checkboxOutline, calculatorOutline });
    }
}
