using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2
{
    public float x;
    public float y;

    public Vec2(float pX = 0, float pY = 0)
    {
        x = pX;
        y = pY;
    }

    public float Length()
    {
        float length = 0;
        length = Mathf.Sqrt(x * x + y * y);
        return length;
    }

    public float GetAngleDegrees()
    {
        float angle = Rad2Deg(Mathf.Atan2(y, x));

        if (angle < 0)
        {
            return 360 + angle;
        }
        else
        {
            return angle;
        }
    }

    public float GetAngleRadians()
    {
        float angle = Mathf.Atan2(y, x);

        if (angle < 0)
        {
            return (2 * Mathf.PI) + angle;
        }
        else
        {
            return angle;
        }
    }

    public void Normalize()
    {
        float length = Length();

        if (length != 0)
        {
            x /= length;
            y /= length;
        }
    }

    public void SetAngleDegrees(float angle)
    {
        angle = Deg2Rad(angle);
        SetAngleRadians(angle);
    }

    public void SetAngleRadians(float angle)
    {
        float length = Length();
        Vec2 newDir = GetUnitVectorRad(angle);

        x = newDir.x * length;
        y = newDir.y * length;
    }

    public void RotateDegrees(float angle)
    {
        angle = Deg2Rad(angle);
        RotateRadians(angle);
    }

    public void RotateRadians(float angle)
    {
        this = new Vec2(Mathf.Cos(angle) * x - Mathf.Sin(angle) * y, Mathf.Cos(angle) * y + Mathf.Sin(angle) * x);
    }

    public void RotateAroundDegrees(Vec2 point, float angle)
    {
        angle = Deg2Rad(angle);
        RotateAroundRadians(point, angle);
    }

    public void RotateAroundRadians(Vec2 point, float angle)
    {
        this -= point;
        RotateRadians(angle);
        this += point;
    }

    public float Dot(Vec2 otherVec)
    {
        return (x * otherVec.x + y * otherVec.y);
    }

    public Vec2 Normal()
    {
        Vec2 normalUnitVec = new Vec2(-y, x);
        normalUnitVec.Normalize();
        return normalUnitVec;
    }

    public void Reflect(float bounciness, Vec2 reflectVec)
    {
        Vec2 normal = reflectVec.Normal();
        this = this - (1 + bounciness) * (Dot(normal)) * normal;
    }

    public static float TOI(float oldDistance, float radius, float newDistance)
    {
        float a = Mathf.Abs(oldDistance) - radius;
        float b = newDistance - oldDistance;
        return Mathf.Abs(a / b);
    }

    public Vec2 Normalized()
    {
        float length = Length();

        if (length != 0)
        {
            return new Vec2(x / length, y / length);
        }
        else
        {
            return this;
        }
    }

    public void SetXY(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    public static Vec2 operator +(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x + right.x, left.y + right.y);
    }

    public static Vec2 operator -(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x - right.x, left.y - right.y);
    }

    public static Vec2 operator *(Vec2 left, float right)
    {
        return new Vec2(left.x * right, left.y * right);
    }

    public static Vec2 operator *(float left, Vec2 right)
    {
        return new Vec2(left * right.x, left * right.y);
    }

    public static float Deg2Rad(float angle)
    {
        return (angle / 180 * Mathf.PI);
    }

    public static float Rad2Deg(float angle)
    {
        return (angle / Mathf.PI * 180);
    }

    public static Vec2 GetUnitVectorDeg(float angle)
    {
        angle = Deg2Rad(angle);
        return new Vec2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public static Vec2 GetUnitVectorRad(float angle)
    {
        return new Vec2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public static Vec2 RandomUnitVector()
    {
        float angle = Utils.Random(0, 361);
        angle = Deg2Rad(angle);
        return new Vec2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public override string ToString()
    {
        return String.Format("({0},{1})", x, y);
    }
}

