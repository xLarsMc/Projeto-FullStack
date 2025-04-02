﻿using Bogus;
using Solution.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public static class RequestRegisterUserJsonBuilder
    {
        public static RequestUserRegisterJson Build(int passwordLength = 10)
        {
            return new Faker<RequestUserRegisterJson>()
                            .RuleFor(user => user.Name, (f) => f.Person.FirstName)
                            .RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Name))
                            .RuleFor(user => user.Password, (f) => f.Internet.Password(passwordLength));
        }
    }
}
