import { Routes, RouterModule } from '@angular/router';
import { GradesPage } from './component/grades.page';
import { NgModule } from '@angular/core';

const routes: Routes = [
    {
        path: '',
        component: GradesPage
    }
];

export const GradesRoutes = RouterModule.forChild(routes);
