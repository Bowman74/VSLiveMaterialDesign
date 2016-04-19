package com.magenic.sharedelementhotfix.sharedelementhotfixandroidlib;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.ActivityOptionsCompat;
import android.support.v4.util.Pair;
import android.view.View;

/**
 * Created by kevinf on 4/16/2016.
 */
public class SharedElementHotfix
{
    public Bundle sharedElementBundle(Activity activity, View view, String sharedelemname)
    {
        ActivityOptionsCompat options = ActivityOptionsCompat.makeSceneTransitionAnimation(activity, view, sharedelemname);
        return options.toBundle ();
    }

    public Bundle sharedElementBundle(Activity activity, Pair<View, String> sharedelems)
    {
        ActivityOptionsCompat options = ActivityOptionsCompat.makeSceneTransitionAnimation (activity, sharedelems);
        return options.toBundle ();
    }
}
