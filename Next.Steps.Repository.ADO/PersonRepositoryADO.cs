using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Next.Steps.Repository.ADO
{
    public class PersonRepositoryADO : IPersonRepository
    {
        private readonly string cs = @"Data Source=DESKTOP-JN31U5B\SQLEXPRESS;" + "Initial Catalog=NextStepsADODatabase;"
                + "Integrated Security=True;" + "User Id=sa;" + "Password=Password1994";

        public bool Create(Person p)
        {
            int recordsAffected;

            string queryString = "INSERT INTO[People](FirstName, LastName, Profession, Birthdate, Email) "
                + "VALUES(@Firstname, @Lastname, @Profession, @Birthdate, @Email) "
                + "SELECT @Id = SCOPE_IDENTITY()";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Firstname", p.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", p.LastName);
                    cmd.Parameters.AddWithValue("@Profession", p.Profession);
                    cmd.Parameters.AddWithValue("@Birthdate", p.Birthdate);
                    cmd.Parameters.AddWithValue("@Email", p.Email);

                    SqlParameter outParam = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outParam);

                    recordsAffected = cmd.ExecuteNonQuery();

                    if (recordsAffected == 1)
                    {
                        p.Id = (int)outParam.Value;
                    }

                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                foreach (var hobby in p.Hobbies)
                {
                    queryString = "INSERT INTO[Hobby](Name, Type, PersonId)"
                    + "VALUES(@Name, @Type, @PersonId)";

                    cmd = new SqlCommand(queryString, conn);

                    try
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Name", hobby.Name);
                        cmd.Parameters.AddWithValue("@Type", hobby.Type);
                        cmd.Parameters.AddWithValue("@PersonId", p.Id);

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Update(Person p)
        {
            int recordsAffected;

            string queryString = "UPDATE People"
                + " SET FirstName = @Firstname, LastName = @Lastname, Profession = @Profession, Birthdate = @Birthdate, Email = @Email"
                + " WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@Firstname", p.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", p.LastName);
                    cmd.Parameters.AddWithValue("@Profession", p.Profession);
                    cmd.Parameters.AddWithValue("@Birthdate", p.Birthdate);
                    cmd.Parameters.AddWithValue("@Email", p.Email);

                    recordsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }

                foreach (var hobby in p.Hobbies)
                {
                    queryString = "UPDATE Hobby"
                        + " SET Name = @Name, Type = @Type)"
                        + " WHERE Id = @Id";

                    cmd = new SqlCommand(queryString, conn);

                    try
                    {
                        cmd.Parameters.AddWithValue("@Name", hobby.Name);
                        cmd.Parameters.AddWithValue("@Type", hobby.Type);
                        cmd.Parameters.AddWithValue("@PersonId", p.Id);

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return recordsAffected > 0;
            }
        }

        public bool Delete(int id)
        {
            int recordsAffected;

            string queryString = "DELETE FROM People"
                + " WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    recordsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return recordsAffected > 0;
        }

        public IEnumerable<Person> GetAll()
        {
            var queryString = "SELECT Id, FirstName, LastName," +
                " Profession, Birthdate, Email"
                + " FROM People";

            var list = new List<Person>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var person = new Person()
                    {
                        Id = (int)dr["Id"],
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"],
                        Profession = (string)dr["Profession"],
                        Birthdate = (DateTime)dr["Birthdate"],
                        Email = (string)dr["Email"]
                    };

                    list.Add(person);
                }

                dr.Close();

                foreach (var person in list)
                {
                    person.Hobbies = GetHobbiesByPersonId(person.Id);
                }

                return list;
            }
        }

        public IEnumerable<Hobby> GetHobbiesByPersonId(int personId)
        {
            var queryString = "SELECT Id, Name, Type"
                    + " FROM Hobby"
                    + " WHERE PersonId = @PersonId";

            var hobList = new List<Hobby>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                cmd.Parameters.AddWithValue("@PersonId", personId);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var hobby = new Hobby()
                    {
                        Id = (int)dr["Id"],
                        Name = (string)dr["Name"],
                        Type = (string)dr["Type"]
                    };

                    hobList.Add(hobby);
                }

                dr.Close();
                return hobList;
            }
        }

        public Person GetById(int id)
        {
            var queryString = "SELECT Id, FirstName, LastName," +
                " Profession, Birthdate, Email"
                + " FROM People"
                + " WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                Person person;

                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                cmd.Parameters.AddWithValue("@Id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    person = new Person()
                    {
                        Id = (int)dr["Id"],
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"],
                        Profession = (string)dr["Profession"],
                        Birthdate = (DateTime)dr["Birthdate"],
                        Email = (string)dr["Email"]
                    };
                    person.Hobbies = GetHobbiesByPersonId(person.Id);
                }
                else
                {
                    person = null;
                }

                dr.Close();
                return person;
            }
        }

        public IEnumerable<Person> Search(string firstName, string lastName)
        {
            var queryString = "SELECT FirstName, LastName"
                + " FROM People"
                + " WHERE FirstName = @Firstname OR LastName = @Lastname";

            var list = new List<Person>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var person = new Person()
                    {
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"]
                    };

                    list.Add(person);
                }

                dr.Close();
                return list;
            }
        }

        public bool Delete(Person p)
        {
            return Delete(p.Id);
        }
    }
}