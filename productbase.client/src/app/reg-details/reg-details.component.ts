import { Component } from '@angular/core';
import { RegistrationService } from '../services/registration.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reg-details',
  templateUrl: './reg-details.component.html',
  styleUrl: './reg-details.component.css'
})
export class RegDetailsComponent { 
  registrationForm: FormGroup;
  constructor(private fb: FormBuilder, private registrationService: RegistrationService) {  // Inject the service
    this.registrationForm = this.fb.group({
      UserName: ['', Validators.required],
      EmailId: ['', [Validators.required, Validators.email]],
      MobileNo: ['', [Validators.required, Validators.minLength(10)]],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      terms: [false, Validators.requiredTrue]
    }, {
      validator: this.passwordMatchValidator  // Add custom validator here
    });
  }

  // Custom validator to check if passwords match
  passwordMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('Password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { mismatch: true };
  }
  onSubmit() {
    if (this.registrationForm.valid) {
      // Exclude confirmPassword and terms fields
      const formData = {
        UserName: this.registrationForm.value.UserName,
        EmailId: this.registrationForm.value.EmailId,
        MobileNo: this.registrationForm.value.MobileNo,
        Password: this.registrationForm.value.Password
      };

      // Call your API service with the filtered formData
      this.registrationService.registerUser(formData).subscribe(
        response => {
          console.log('API call successful', response);
        },
        error => {
          console.error('API call failed', error);
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
}

