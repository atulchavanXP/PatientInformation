import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PatientListComponent } from './patient/patient-list/patient-list.component';
import { PatientUpsertComponent } from './patient/patient-upsert/patient-upsert.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PatientListComponent,
    PatientUpsertComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: PatientListComponent, pathMatch: 'full' },
      { path: 'patients', component: PatientListComponent },
      { path: 'add', component: PatientUpsertComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
