import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { MaltidReportsComponent } from './components/reports/maltidreports.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { GroupsComponent } from './components/groups/groups.component';
import { ReportDateComponent } from './components/reportdate/reportdate.component';
import { ReportComponent } from './components/report/report.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        MaltidReportsComponent,
        CategoriesComponent,
        GroupsComponent,
        ReportDateComponent,
        ReportComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'categories', component: CategoriesComponent },
            { path: 'groups', component: GroupsComponent },
            { path: 'reports', component: MaltidReportsComponent },
            { path: 'report-date', component: ReportDateComponent },
            { path: 'report', component: ReportComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
