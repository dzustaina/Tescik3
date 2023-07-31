import { HttpClient } from '@angular/common/http';
import {Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
    providedIn: 'root'
})

export class UserService{
    constructor(private fb:FormBuilder, private http:HttpClient){ }

    formModel = this.fb.group({
        FirstName:['', Validators.required],
        LastName:['', [Validators.required, Validators.email]],
        Email:['', Validators.required],
        Passwords: this.fb.group({
            Password:['', [Validators.required, Validators.minLength(8)]],
        ConfirmPassowrd:['', Validators.required]
        },{validators : this.comparePasswords})
        
    });

    comparePasswords(fb:FormGroup){
        const confirmPswrdCtrl = fb.get('ConfirmPassword');
        if(confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors){
            if(fb.get('Passwords.Password')?.value!= confirmPswrdCtrl?.value)
            confirmPswrdCtrl?.setErrors({passwordMismatch: true});
            else
            confirmPswrdCtrl?.setErrors(null);
        }
    }
    register(){
        var body = {
            FirstName: this.formModel.value.FirstName,
            LastName: this.formModel.value.LastName,
            Email: this.formModel.value.Email,
            Password: this.formModel.value.Passwords,
        };
    }
}