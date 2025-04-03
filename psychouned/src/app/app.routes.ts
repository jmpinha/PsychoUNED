import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AddDataPageComponent } from './pages/add-data/add-data-page.component';
import { TestsPageComponent } from './pages/tests-page/tests-page.component';
import { GradesPageComponent } from './pages/grades/grades-page.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'calculadora',
        pathMatch: 'full',
    },
    {
        path: 'nuevosDatos',
        component: AddDataPageComponent
    },
    {
        path: 'asignaturas',
        loadComponent: () => import('src/app/pages/subjects/subjects-page.component')
    },
    {
        path: 'tests',
        component:TestsPageComponent
    },
    {
        path: 'calculadora',
        component:GradesPageComponent
    },
    // {
    //     path: 'notes',
    //     loadComponent: () =>
    //         import('./pages/notes/component/notes.page').then((m) => m.NotesPage),
    // },
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
